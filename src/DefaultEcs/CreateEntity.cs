using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public class CreateEntity_DefaultEcs : CreateEntity
{
    private World world;

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
        for (int n = 0; n < Entities; n++) {
            var entity = world.CreateEntity();
            entity.Set(new Component1 { Value = n });
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++) {
            var entity = world.CreateEntity();
            entity.Set(new Component1 { Value = n });
            entity.Set(new Component2 { Value = n });
            entity.Set(new Component3 { Value = n });
        }
    }
}