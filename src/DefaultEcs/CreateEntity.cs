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
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.CreateEntity();
            entity.Set<Component1>();
        }
    }

    protected override void CreateEntity5Components()
    {
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.CreateEntity();
            entity.Set<Component1>();
            entity.Set<Component2>();
            entity.Set<Component3>();
        }
    }
}