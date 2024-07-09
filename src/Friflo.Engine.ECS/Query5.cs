using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Query5
{
    private ArchetypeQuery<Component1,Component2,Component3,Component4,Component5> query;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        for (int n = 0; n < Constant.EntityCount; n++) {
            var entity = world.CreateEntity();
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        query = world.Query<Component1,Component2,Component3,Component4,Component5>();
    }
    
    // [Benchmark]
    public void Run() {
        foreach (var (components1, components2, components3, components4, components5, _) in query.Chunks) {
            foreach (ref var _ in components1.Span) {
            }
        }
    }
}