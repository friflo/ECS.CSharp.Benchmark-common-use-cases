using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_FlecsNet
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
    
    [Benchmark]
    public void Run()
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