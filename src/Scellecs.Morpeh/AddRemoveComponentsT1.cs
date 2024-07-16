using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.AddRemoveComponentsT1)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT1_Morpeh
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
        }
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
        }
        world.Commit();
    }
}