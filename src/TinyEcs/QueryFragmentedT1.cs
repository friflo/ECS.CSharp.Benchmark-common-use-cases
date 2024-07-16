using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_TinyEcs
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        query = world.QueryBuilder().With<Component1>().Build();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n]; 
                                entity.Set(new Component1());
            if ((n &   1) != 0) entity.Set(new Component2());
            if ((n &   2) != 0) entity.Set(new Component3());
            if ((n &   4) != 0) entity.Set(new Component4());
            if ((n &   8) != 0) entity.Set(new Component5());
        }
        Assert.AreEqual(Constants.FragmentationCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var (e, c1) in query.Iter<Component1>()) {
            for (var n = 0; n < e.Length; n++) {
                c1[n].Value++;    
            }
        }
    }
}