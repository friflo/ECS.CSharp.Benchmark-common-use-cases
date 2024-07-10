using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Fennecs
{
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}