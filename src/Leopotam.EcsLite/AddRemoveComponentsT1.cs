using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class AddRemoveComponentsT1
{
    private EcsWorld            world;
    private int[]               entities;
    private EcsPool<Component1> ecsPoolC1;
    
    [GlobalSetup]
    public void Setup() {
        world       = new EcsWorld();
        entities    = world.CreateEntities(Constants.EntityCount);
        ecsPoolC1   = world.GetPool<Component1>();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }

    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Add(entity);
        }
        foreach (var entity in entities) {
            ecsPoolC1.Del(entity);
        }
    }
}