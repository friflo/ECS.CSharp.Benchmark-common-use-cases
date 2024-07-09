using Arch.Core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Arch;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class CreateWorld
{
    [GlobalSetup]
    public void Setup() { }
    
    [GlobalCleanup]
    public void Shutdown() { }
    
    [Benchmark]
    public void Run()
    {
        var world = World.Create();
        World.Destroy(world);
    }
}