using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class CreateBulk_EntitiesDb : CreateBulk
{
    private EntityDatabase db;

    [IterationSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
    }

    [IterationCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        db.Reserve<Component1>(Entities);
        for (int n = 0; n < Entities; n++)
        {
            db.Create(new Component1(n));
        }
    }

    protected override void CreateEntity3Components()
    {
        db.Reserve<Component1, Component2, Component3>(Entities);
        for (int n = 0; n < Entities; n++)
        {
            db.Create(new Component1(n), new Component2(n), new Component3(n));
        }
    }
}
