using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Leopotam : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = new EcsWorld();
        world.Destroy();
    }
}