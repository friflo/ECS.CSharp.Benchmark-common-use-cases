using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class CreateWorld
{
    [GlobalSetup]
    public void Setup() { }
    
    [GlobalCleanup]
    public void Shutdown() {
    }
    
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}