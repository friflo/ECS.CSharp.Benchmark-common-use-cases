using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class CreateBulk_Fennecs : CreateBulk
{
    private World   world;

    [IterationSetup]
    public void Setup()
    {
        world = new World();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        world.Entity()
            .Add(new Component1())
            .Spawn(Constants.CreateBulkCount);
        for (int n = 0; n < world.Count; n++) {
            world[n].Ref<Component1>().Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        world.Entity()
            .Add(new Component1())
            .Add(new Component2())
            .Add(new Component3())
            .Spawn(Constants.CreateBulkCount);
        for (int n = 0; n < world.Count; n++) {
            var entity = world[n];
            entity.Ref<Component1>().Value = n;
            entity.Ref<Component1>().Value = n;
            entity.Ref<Component1>().Value = n;
        }
    }
}