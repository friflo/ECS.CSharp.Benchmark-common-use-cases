using BenchmarkDotNet.Attributes;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Myriad
{
    [Benchmark]
    public void Run()
    {
        var world = new WorldBuilder().Build();
        world.Dispose();
    }
}