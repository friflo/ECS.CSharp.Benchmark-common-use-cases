using BenchmarkDotNet.Attributes;
using Frent.Core;
using Frent;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemove_Frent : CommandBufferAddRemove
{
    private Entity[]        entities;
    private CommandBuffer commandBuffer;

    [GlobalSetup]
    public void Setup()
    {
        var world       = new World();
        entities        = world.CreateEntities(Entities);
        commandBuffer   = new CommandBuffer(world);
    }

    [Benchmark(Baseline = true)]
    public override void Run()
    {
        var cb = commandBuffer;
        foreach (var entity in entities) {
            cb.AddComponent(entity, new Component1());
            cb.AddComponent(entity, new Component2());
        }
        cb.Playback(); // Apply changes 1

        foreach (var entity in entities) {
            cb.RemoveComponent<Component1>(entity);
            cb.RemoveComponent<Component2>(entity);
        }
        cb.Playback(); // Apply changes 2
    }
}