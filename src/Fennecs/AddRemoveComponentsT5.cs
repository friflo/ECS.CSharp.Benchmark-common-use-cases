using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveComponentsT5)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT5_Fennecs
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
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
            entity.Add(new Component1());
            entity.Add(new Component2());
            entity.Add(new Component3());
            entity.Add(new Component4());
            entity.Add(new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
            entity.Remove<Component2>();
            entity.Remove<Component3>();
            entity.Remove<Component4>();
            entity.Remove<Component5>();
        }
    }
}