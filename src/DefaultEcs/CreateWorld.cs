using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_DefaultEcs
{
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}