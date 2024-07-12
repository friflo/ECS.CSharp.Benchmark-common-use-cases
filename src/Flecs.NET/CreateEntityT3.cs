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
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Entity();
            entity.Set<Component1>(default);
            entity.Set<Component2>(default);
            entity.Set<Component3>(default);
        }
    }
}