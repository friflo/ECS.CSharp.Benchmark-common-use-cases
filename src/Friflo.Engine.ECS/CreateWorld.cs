using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class CreateWorld
{
    [Benchmark(Baseline = true)]
    public void Run()
    {
        _ = new EntityStore();
        // nothing to Dispose() - has no unmanaged resources
    }
}