using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_FlecsNet
{
    private World       world;
    private Entity[]    entities;
    
    [IterationSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Destruct();
        }
    }
}