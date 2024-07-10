using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class QueryT5
{
    private World                                                           world;
    private Stream<Component1,Component2,Component3,Component4,Component5>  stream;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        for (int n = 0; n < EntityCount; n++) {
            var entity = world.Spawn();
            entity.Add<Component1>();
            entity.Add<Component2>();
            entity.Add<Component3>();
            entity.Add<Component4>();
            entity.Add<Component5>();
        }
        stream = world.Query<Component1>().Compile().Stream<Component1,Component2,Component3,Component4,Component5>();
        Assert.AreEqual(EntityCount, stream.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run() {
        stream.Raw((components1, components2, components3, components4, components5) => {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].value = span2[n].value + span3[n].value + span4[n].value * span5[n].value;  
            }
        });
    }
}