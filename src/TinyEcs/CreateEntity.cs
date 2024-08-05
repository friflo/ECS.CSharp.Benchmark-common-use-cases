using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class CreateEntity_TinyEcs : CreateEntity
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
        var archetype = world.Archetype<Component1>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Entity(archetype).Get<Component1>().Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        var archetype = world.Archetype<Component1, Component2, Component3>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Entity(archetype);
            entity.Get<Component1>().Value = n;
            entity.Get<Component2>().Value = n;
            entity.Get<Component3>().Value = n;
        }
    }
}