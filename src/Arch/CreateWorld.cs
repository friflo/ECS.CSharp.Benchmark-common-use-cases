using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_Arch
{
    [Benchmark]
    public void Run()
    {
        var world = World.Create();
        World.Destroy(world);
    }
}