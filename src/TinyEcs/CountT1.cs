using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class CountT1
{
    private World               world;
    private Query<Component1>   query;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Assert.AreEqual(Constant.EntityCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        _ = query.Count();
    }
}