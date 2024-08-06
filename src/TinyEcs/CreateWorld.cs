using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class CreateWorld_TinyEcs : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = new World();
        world.Dispose();
    }
}