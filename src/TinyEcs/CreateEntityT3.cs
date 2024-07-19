using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_TinyEcs
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

    [Benchmark]
    public void Run()
    {
        var archetype = world.Archetype<Component1, Component2, Component3>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Entity(archetype);
        }
    }
}