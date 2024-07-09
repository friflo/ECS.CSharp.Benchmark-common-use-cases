using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Query1
{
    private World               world;
    private Stream<Component1>  stream;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        for (int n = 0; n < Constant.EntityCount; n++) {
            var entity = world.Spawn();
            entity.Add<Component1>();
        }
        stream = world.Query<Component1>().Compile().Stream<Component1>();
        Assert.AreEqual(Constant.EntityCount, stream.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run() {
        stream.Raw((Memory<Component1> components) => {
            foreach (Component1 _ in components.Span) {
            }
        });
    }
}