using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class CountT1
{
    private EcsWorld    world;
    private EcsFilter   filter;
    
    [GlobalSetup]
    public void Setup() {
        world = new EcsWorld();
        world.CreateEntities(Constant.EntityCount).AddComponents(world);
        filter = world.Filter<Component1>().End();
        Assert.AreEqual(Constant.EntityCount, filter.GetEntitiesCount());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        _ = filter.GetEntitiesCount();
    }
}