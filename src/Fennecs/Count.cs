using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Count
{
    private Query    query;
    private World    world;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        for (int n = 0; n < EntityCount; n++) {
            var entity = world.Spawn();
            entity.Add<Component1>();
        }
        query = world.Query<Component1>().Compile();
        Assert.AreEqual(EntityCount, query.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run() {
        _ = query.Count;
    }
}