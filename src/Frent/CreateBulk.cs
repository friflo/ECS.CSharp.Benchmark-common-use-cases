using BenchmarkDotNet.Attributes;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class CreateBulk_Frent : CreateBulk
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
        world.EnsureCapacity<Component1>(Entities);
        for (int n = 0; n < Entities; n++)
        {
            world.Create<Component1>(new(n));
        }
    }

    protected override void CreateEntity3Components()
    {
        world.EnsureCapacity<Component1>(Entities);
        for (int n = 0; n < Entities; n++)
        {
            world.Create<Component1, Component2, Component3>(new(n), new(n), new(n));
        }
    }
}