using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Count
{
    private ArchetypeQuery<Component1>    query;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        BenchUtils.AddComponents(BenchUtils.CreateEntities(world, EntityCount));
        query = world.Query<Component1>();
        Assert.AreEqual(EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run() {
        _ = query.Count;
    }
}