using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class AddRemoveComponentsT5
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
            entity.Set(new Component2());
            entity.Set(new Component3());
            entity.Set(new Component4());
            entity.Set(new Component5());
        }
        foreach (var entity in entities) {
            entity.Unset<Component1>();
            entity.Unset<Component2>();
            entity.Unset<Component3>();
            entity.Unset<Component4>();
            entity.Unset<Component5>();
        }
    }
}