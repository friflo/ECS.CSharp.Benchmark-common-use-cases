using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Friflo
{
    [Benchmark(Baseline = true)]
    public void Run()
    {
        _ = new EntityStore();
        // nothing to Dispose() - has no unmanaged resources
    }
}