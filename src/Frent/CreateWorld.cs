using BenchmarkDotNet.Attributes;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Frent : CreateWorld
{
    [Benchmark]
    public override void Run()
    {
        var world = new World();
        world.Dispose();
    }
}