using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Fennecs : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = new World();
        world.Dispose();
    }
}