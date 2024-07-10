using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class QueryT1
{
    private World               world;
    private Stream<Component1>  stream;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        BenchUtils.AddComponents(BenchUtils.CreateEntities(world, EntityCount));
        stream = world.Query<Component1>().Compile().Stream<Component1>();
        Assert.AreEqual(EntityCount, stream.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        stream.Raw(components => {
            foreach (Component1 _ in components.Span) {
            }
        });
    }
}