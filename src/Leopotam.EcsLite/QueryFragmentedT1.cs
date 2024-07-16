using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_Leopotam
{
    private EcsWorld            world;
    private EcsFilter           filter;
    private EcsPool<Component1> c1;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new EcsWorld();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        c1      = world.GetPool<Component1>();
        var c2  = world.GetPool<Component2>();
        var c3  = world.GetPool<Component3>();
        var c4  = world.GetPool<Component4>();
        var c5  = world.GetPool<Component5>();
        filter  = world.Filter<Component1>().End();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n];
                                c1.Add(entity);
            if ((n &   1) != 0) c2.Add(entity);
            if ((n &   2) != 0) c3.Add(entity);
            if ((n &   4) != 0) c4.Add(entity);
            if ((n &   8) != 0) c5.Add(entity);
        }
        Assert.AreEqual(Constants.FragmentationCount, filter.GetEntitiesCount());
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
            ++c1.Get(entities[i]).Value;
        }
    }
}