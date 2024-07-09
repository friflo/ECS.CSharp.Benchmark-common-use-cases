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
        for (int n = 0; n < 10; n++) {
            world.Spawn();
        }
        query = world.Query<Component1>().Compile();
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