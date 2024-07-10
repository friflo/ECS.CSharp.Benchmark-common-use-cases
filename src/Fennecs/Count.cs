using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
public class Count
{
    private Query    query;
    private World    world;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        query = world.Query<Component1>().Compile();
        Assert.AreEqual(Constant.EntityCount, query.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        _ = query.Count;
    }
}