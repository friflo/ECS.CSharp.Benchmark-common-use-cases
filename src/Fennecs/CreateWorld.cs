using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class CreateWorld
{
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}