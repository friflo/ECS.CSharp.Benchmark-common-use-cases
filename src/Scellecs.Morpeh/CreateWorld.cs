using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Morpeh
{
    [Benchmark]
    public void Run()
    {
        var world = World.Create();
        world.Dispose();
    }
}