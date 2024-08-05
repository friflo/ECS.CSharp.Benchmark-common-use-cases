using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class CreateEntity_FlecsNet : CreateEntity
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
        world.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        var table = world.Table().Add<Component1>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Entity(table);
        }
    }

    protected override void CreateEntity5Components()
    {
        var table = world.Table()
            .Add<Component1>()
            .Add<Component2>()
            .Add<Component3>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Entity(table);
        }
    }
}