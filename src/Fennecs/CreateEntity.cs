using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Fennecs : CreateEntity
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
        for (int n = 0; n < Entities; n++) {
            world.Spawn().Add(new Component1{ Value = n });
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++) {
            var entity = world.Spawn();
            entity.Add(new Component1{ Value = n });
            entity.Add(new Component2{ Value = n });
            entity.Add(new Component3{ Value = n });
        }
    }
}