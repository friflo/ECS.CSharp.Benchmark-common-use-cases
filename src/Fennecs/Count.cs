using System.Diagnostics;
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
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        for (int n = 0; n < Constant.EntityCount; n++) {
            var entity = world.Spawn();
            entity.Add<Component1>();
        }
        query = world.Query<Component1>().Compile();
        Assert.AreEqual(Constant.EntityCount, query.Count);
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