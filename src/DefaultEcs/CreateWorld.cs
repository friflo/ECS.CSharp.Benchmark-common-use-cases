using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public class CreateWorld_DefaultEcs : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = new World();
        world.Dispose();
    }
}