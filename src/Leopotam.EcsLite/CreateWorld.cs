using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Leopotam
{
    [Benchmark]
    public void Run()
    {
        var world = new EcsWorld();
        world.Destroy();
    }
}