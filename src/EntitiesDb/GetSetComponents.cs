using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class GetSetComponents_EntitiesDb : GetSetComponents
{
    private EntityDatabase db;
    private Entity[] entities;

    [GlobalSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        entities = db.CreateEntitiesWithComponents(Entities);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities)
        {
            db.Write<Component1>(entity) = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities)
        {
            var data = db.GetEntityData(entity);
            data.Write<Component1>() = new Component1();
            data.Write<Component2>() = new Component2();
            data.Write<Component3>() = new Component3();
            data.Write<Component4>() = new Component4();
            data.Write<Component5>() = new Component5();
        }
    }
}
