using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_TinyEcs
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.QueryBuilder().With<Component1>().Build();
        Check.AreEqual(Constants.EntityCount, query.Count());
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