using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[ShortRunJob]
[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_FlecsNet
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    [Benchmark]
    public void Run()
    {
        world.DeferBegin();
        foreach (var entity in entities) {
            entity
                .Add<Component1>()
                .Add<Component2>();
        }
        world.DeferEnd();

        world.DeferBegin();
        foreach (var entity in entities) {
            entity
                .Remove<Component1>()
                .Remove<Component2>();
        }
        world.DeferEnd();
    }
}