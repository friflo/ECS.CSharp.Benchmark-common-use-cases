using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_TinyEcs
{
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}