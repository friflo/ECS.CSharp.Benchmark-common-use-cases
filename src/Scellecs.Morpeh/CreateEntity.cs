using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Morpeh : CreateEntity
{
    private World world;

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
        var stash1 = world.GetStash<Component1>();
        for (int n = 0; n < Entities; n++)
        {
            var entity = world.CreateEntity();
            stash1.Add(entity).Value = n;
        }
        world.Commit();
    }

    protected override void CreateEntity3Components()
    {
        var stash1 = world.GetStash<Component1>();
        var stash2 = world.GetStash<Component2>();
        var stash3 = world.GetStash<Component3>();
        for (int n = 0; n < Entities; n++)
        {
            var entity = world.CreateEntity();
            stash1.Add(entity).Value = n;
            stash2.Add(entity).Value = n;
            stash3.Add(entity).Value = n;
        }
        world.Commit();
    }
}