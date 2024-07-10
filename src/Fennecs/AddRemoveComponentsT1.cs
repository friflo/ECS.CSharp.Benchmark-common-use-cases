using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveComponentsT1)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT1_Fennecs
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
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
        }
    }
}