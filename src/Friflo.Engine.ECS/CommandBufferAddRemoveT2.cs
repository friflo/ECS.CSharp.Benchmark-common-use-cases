using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_Friflo
{
    private Entity[]        entities;
    private CommandBuffer   commandBuffer;
    
    [GlobalSetup]
    public void Setup()
    {
        var world       = new EntityStore();
        entities        = world.CreateEntities(Constants.EntityCount);
        commandBuffer   = world.GetCommandBuffer();
        commandBuffer.ReuseBuffer = true;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
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