using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class CreateEntity_EntitiesDb : CreateEntity
{
    private EntityDatabase db;

    [IterationSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        db.CreateEntities(1);
        db.CreateEntitiesWithComponents(1);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        for (int n = 0; n < Entities; n++)
        {
            db.Create(new Component1(n));
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++)
        {
            db.Create(new Component1(n), new Component2(n), new Component3(n));
        }
    }
}
