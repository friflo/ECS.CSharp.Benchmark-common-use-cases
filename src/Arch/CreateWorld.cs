using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class CreateWorld_Arch : CreateWorld
{
    [Benchmark]
    public override void Run()
    {
        var world = World.Create();
        World.Destroy(world);
    }
}