using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Query1
{
    private Query    query;
    
    [GlobalSetup]
    public void Setup() {
        var world = new World();
        for (int n = 0; n < 10; n++) {
            world.Spawn();
        }
        query = world.Query<Component1>().Compile();
    }
    
    [Benchmark]
    public void Run() {
        query.Stream<Component1>().Raw((Memory<Component1> components) => {
            foreach (Component1 _ in components.Span) {
            }
        });
    }
}