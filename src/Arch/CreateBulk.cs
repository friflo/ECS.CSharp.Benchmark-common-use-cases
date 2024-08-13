using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class CreateBulk_Arch : CreateBulk
{
    private World   world;
    private static readonly Signature ComponentTypes1 = new(typeof(Component1));
    private static readonly Signature ComponentTypes3 = new(typeof(Component1),typeof(Component2),typeof(Component3));

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
        world.Reserve(ComponentTypes1, Entities);
        for (int n = 0; n < Entities; n++)
        {
            world.Create(n);
        }
    }

    protected override void CreateEntity3Components()
    {
        world.Reserve(ComponentTypes3, Entities);
        for (int n = 0; n < Entities; n++)
        {
            world.Create(n,n,n);
        }
    }
}