using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class QueryT5
{
    private ArchetypeQuery<Component1,Component2,Component3,Component4,Component5> query;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(EntityCount).AddComponents();
        query = world.Query<Component1,Component2,Component3,Component4,Component5>();
        Assert.AreEqual(EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var (components1, components2, components3, components4, components5, _) in query.Chunks)
        {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].value = span2[n].value + span3[n].value + span4[n].value + span5[n].value;
            }
        }
    }
}