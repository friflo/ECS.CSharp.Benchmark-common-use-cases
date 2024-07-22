using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_TinyEcs
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
        Check.AreEqual(Constants.EntityCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var (e, c1, c2, c3, c4, c5) in query.Iter<Component1, Component2, Component3, Component4, Component5>()) {
            for (var n = 0; n < e.Length; n++) {
                c1[n].Value = c2[n].Value + c3[n].Value + c4[n].Value + c5[n].Value;
            }
        }
    }
}