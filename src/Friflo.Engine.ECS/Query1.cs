using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Query1
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        for (int n = 0; n < 10; n++) {
            world.CreateEntity();
        }
        query = world.Query<Component1>();
    }
    
    [Benchmark]
    public void Run() {
        foreach (var (components, _) in query.Chunks) {
            foreach (ref var _ in components.Span) {
            }
        }
    }
}