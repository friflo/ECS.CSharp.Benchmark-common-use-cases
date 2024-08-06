using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Morpeh : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = World.Create();
        world.Dispose();
    }
}