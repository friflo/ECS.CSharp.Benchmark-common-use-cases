using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveComponentsT5)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT5_Morpeh
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
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
            entity.RemoveComponent<Component2>();
            entity.RemoveComponent<Component3>();
            entity.RemoveComponent<Component4>();
            entity.RemoveComponent<Component5>();
        }
        world.Commit();
    }
}