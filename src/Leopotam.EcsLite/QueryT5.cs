using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class QueryT5
{
    private EcsWorld            world;
    private EcsFilter           filter;
    private EcsPool<Component1> c1;
    private EcsPool<Component2> c2;
    private EcsPool<Component3> c3;
    private EcsPool<Component4> c4;
    private EcsPool<Component5> c5;
    
    [GlobalSetup]
    public void Setup() {
        world = new EcsWorld();
        world.CreateEntities(Constant.EntityCount).AddComponents(world);
        c1      = world.GetPool<Component1>();
        c2      = world.GetPool<Component2>();
        c3      = world.GetPool<Component3>();
        c4      = world.GetPool<Component4>();
        c5      = world.GetPool<Component5>();
        filter  = world.Filter<Component1>().Inc<Component2>().Inc<Component3>().Inc<Component4>().Inc<Component5>().End();
        Assert.AreEqual(Constant.EntityCount, filter.GetEntitiesCount());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        int[] entities = filter.GetRawEntities();
        for (int i = 0, iMax = filter.GetEntitiesCount(); i < iMax; i++)
        {
            var entity = entities[i];
            c1.Get(entity).value =
            c2.Get(entity).value +
            c3.Get(entity).value +
            c4.Get(entity).value +
            c5.Get(entity).value;
        }
    }
}