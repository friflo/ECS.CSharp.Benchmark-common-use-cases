using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class CreateWorld_FlecsNet : CreateWorld
{
    [Benchmark]
    public override  void Run()
    {
        var world = World.Create();
        world.Dispose();
    }
}