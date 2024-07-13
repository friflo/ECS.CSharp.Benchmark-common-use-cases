using BenchmarkDotNet.Attributes;
using DefaultEcs.Command;

namespace DefaultEcs;

[ShortRunJob]
[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_DefaultEcs
{
    private World                   world;
    private Entity[]                entities;
    private EntityCommandRecorder   commandBuffer;
    
    [GlobalSetup]
    public void Setup()
    {
        world           = new World();
        entities        = world.CreateEntities(Constants.EntityCount);
        commandBuffer   = new EntityCommandRecorder();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        commandBuffer.Dispose();
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        var cb = commandBuffer;
        foreach (var entity in entities) {
            var entityRecord = cb.Record(entity);
            entityRecord.Set<Component1>();
            entityRecord.Set<Component2>();
        }
        cb.Execute(); // Apply changes 1
        
        foreach (var entity in entities) {
            var entityRecord = cb.Record(entity);
            entityRecord.Remove<Component1>();
            entityRecord.Remove<Component2>();
        }
        cb.Execute(); // Apply changes 2
    }
}