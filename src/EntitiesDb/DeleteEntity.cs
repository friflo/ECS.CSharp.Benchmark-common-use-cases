using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class DeleteEntity_EntitiesDb : DeleteEntity
{
    private EntityDatabase db;
    private Entity[] entities;

    [IterationSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        entities = db.CreateEntitiesWithComponents(Entities);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities)
        {
            db.Destroy(entity);
        }
    }
}
