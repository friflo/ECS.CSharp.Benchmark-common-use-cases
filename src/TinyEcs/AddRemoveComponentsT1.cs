using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class AddRemoveComponentsT1
{
    private World           world;
    private EntityView[]    entities;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constant.EntityCount);
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