using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class QueryT1
{
    private EcsWorld            world;
    private EcsFilter           filter;
    private EcsPool<Component1> c1;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new EcsWorld();
        world.CreateEntities(Constants.EntityCount).AddComponents(world);
        c1      = world.GetPool<Component1>();
        filter  = world.Filter<Component1>().End();
        Assert.AreEqual(Constants.EntityCount, filter.GetEntitiesCount());
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        int[] entities = filter.GetRawEntities();
        for (int i = 0, iMax = filter.GetEntitiesCount(); i < iMax; i++) {
            ++c1.Get(entities[i]).value;
        }
    }
}