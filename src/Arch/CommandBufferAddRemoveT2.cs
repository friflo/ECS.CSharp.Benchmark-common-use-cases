using Arch.Buffer;
using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_Arch
{
    private World           world;
    private Entity[]        entities;
    private CommandBuffer   commandBuffer;
    
    [GlobalSetup]
    public void Setup()
    {
        world           = World.Create();
        entities        = world.CreateEntities(Constants.EntityCount);
        commandBuffer   = new CommandBuffer(Constants.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        commandBuffer.Dispose();
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        var cb = commandBuffer;
        foreach (var entity in entities) {
            cb.Add(entity, new Component1());
            cb.Add(entity, new Component2());
        }
        cb.Playback(world, false); // Apply changes 1
        
        foreach (var entity in entities) {
            cb.Remove<Component1>(entity);
            cb.Remove<Component2>(entity);
        }
        cb.Playback(world, false); // Apply changes 2
    }
}