using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_FlecsNet
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
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Entity();
            entity.Set<Component1>(default);
        }
    }
}