using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
[BenchmarkCategory(Category.GetSetComponentsT1)]
// ReSharper disable once InconsistentNaming
public class GetSetComponentsT1_Leopotam
{
    private EcsWorld            world;
    private int[]               entities;
    private EcsPool<Component1> ecsPoolC1;
    
    [GlobalSetup]
    public void Setup() {
        world       = new EcsWorld();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents(world);
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
            ecsPoolC1.Get(entity) = new Component1();
        }
    }
}