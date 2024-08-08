using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemove_FlecsNet : CommandBufferAddRemove
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Entities);
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        world.DeferBegin();
        foreach (var entity in entities) {
            entity
                .Set(new Component1())
                .Set(new Component2());
        }
        world.DeferEnd(); // Apply changes 1

        world.DeferBegin();
        foreach (var entity in entities) {
            entity
                .Remove<Component1>()
                .Remove<Component2>();
        }
        world.DeferEnd(); // Apply changes 2
    }
}