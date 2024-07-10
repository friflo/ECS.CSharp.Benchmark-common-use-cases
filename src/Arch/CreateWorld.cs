using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class CreateWorld
{
    [Benchmark]
    public void Run()
    {
        var world = World.Create();
        World.Destroy(world);
    }
}