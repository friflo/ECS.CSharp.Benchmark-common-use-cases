using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Leopotam
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
        world.CreateEntities(Constants.EntityCount).AddComponents(world);
        c1      = world.GetPool<Component1>();
        c2      = world.GetPool<Component2>();
        c3      = world.GetPool<Component3>();
        c4      = world.GetPool<Component4>();
        c5      = world.GetPool<Component5>();
        filter  = world.Filter<Component1>().Inc<Component2>().Inc<Component3>().Inc<Component4>().Inc<Component5>().End();
        Check.AreEqual(Constants.EntityCount, filter.GetEntitiesCount());
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
            c1.Get(entity).Value =
            c2.Get(entity).Value +
            c3.Get(entity).Value +
            c4.Get(entity).Value +
            c5.Get(entity).Value;
        }
    }
}