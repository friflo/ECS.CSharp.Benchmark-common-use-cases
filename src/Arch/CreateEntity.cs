using Arch.Core;
using Arch.Core.Utils;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Arch : CreateEntity
{
    private World   world;
    private static readonly ComponentType[] ComponentTypes1 = [typeof(Component1)];
    private static readonly ComponentType[] ComponentTypes3 = [typeof(Component1),typeof(Component2),typeof(Component3)];

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
        world.Reserve(ComponentTypes1, Constants.CreateEntityCount);
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Create(ComponentTypes1);
            world.Get<Component1>(entity).Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        world.Reserve(ComponentTypes3, Constants.CreateEntityCount);
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Create(ComponentTypes3);
            world.Get<Component1>(entity).Value = n;
            world.Get<Component2>(entity).Value = n;
            world.Get<Component3>(entity).Value = n;
        }
    }
}