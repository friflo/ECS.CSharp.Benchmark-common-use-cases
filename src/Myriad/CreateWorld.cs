using BenchmarkDotNet.Attributes;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Myriad : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = new WorldBuilder().Build();
        world.Dispose();
    }
}