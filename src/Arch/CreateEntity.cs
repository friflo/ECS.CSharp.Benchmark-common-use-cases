using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Arch : CreateEntity
{
    private World   world;

    [IterationSetup]
    public void Setup()
    {
        world = World.Create();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    protected override void CreateEntity1Component()
    {
        for (int n = 0; n < Entities; n++) {
            world.Create(new Component1{ Value = n });
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++) {
            world.Create(
                new Component1{ Value = n },
                new Component2{ Value = n },
                new Component3{ Value = n });
        }
    }
}