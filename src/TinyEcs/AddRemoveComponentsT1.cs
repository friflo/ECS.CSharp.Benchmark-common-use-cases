using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveComponentsT1)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT1_TinyEcs
{
    private World           world;
    private EntityView[]    entities;
    
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
            entity.Set(new Component1());
        }
        foreach (var entity in entities) {
            entity.Unset<Component1>();
        }
    }
}