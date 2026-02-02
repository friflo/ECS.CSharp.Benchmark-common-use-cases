using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class AddRemoveComponents_EntitiesDb : AddRemoveComponents
{
    private EntityDatabase db;
    private Entity[] entities;

    [GlobalSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        entities = db.CreateEntities(Entities);
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
            db.Add(entity, new Component1());
        }
        foreach (var entity in entities)
        {
            db.Remove<Component1>(entity);
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities)
        {
            db.Add(entity, new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities)
        {
            db.Remove<Component1, Component2, Component3, Component4, Component5>(entity);
        }
    }
}
