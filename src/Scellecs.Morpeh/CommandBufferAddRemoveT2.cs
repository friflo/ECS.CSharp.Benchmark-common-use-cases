using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_Morpeh
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
        foreach (var entity in entities) {
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
        }
        world.Commit(); // Apply changes 1
        
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
            entity.RemoveComponent<Component2>();
        }
        world.Commit(); // Apply changes 2
    }
}