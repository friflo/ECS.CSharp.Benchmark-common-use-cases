using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class Count
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Assert.AreEqual(Constant.EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run() {
        _ = query.Count;
    }
}