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
        for (int n = 0; n < 10; n++) {
            world.Spawn();
        }
        stream = world.Query<Component1>().Compile().Stream<Component1>();
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