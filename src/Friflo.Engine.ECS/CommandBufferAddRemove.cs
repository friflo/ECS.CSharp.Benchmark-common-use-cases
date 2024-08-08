using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemove_Friflo : CommandBufferAddRemove
{
    private Entity[]        entities;
    private CommandBuffer   commandBuffer;

    [GlobalSetup]
    public void Setup()
    {
        var world       = new EntityStore();
        entities        = world.CreateEntities(Entities);
        commandBuffer   = world.GetCommandBuffer();
        commandBuffer.ReuseBuffer = true;
    }

    [Benchmark(Baseline = true)]
    public override void Run()
    {
        var cb = commandBuffer;
        foreach (var entity in entities) {
            cb.AddComponent(entity.Id, new Component1());
            cb.AddComponent(entity.Id, new Component2());
        }
        cb.Playback(); // Apply changes 1

        foreach (var entity in entities) {
            cb.RemoveComponent<Component1>(entity.Id);
            cb.RemoveComponent<Component2>(entity.Id);
        }
        cb.Playback(); // Apply changes 2
    }
}