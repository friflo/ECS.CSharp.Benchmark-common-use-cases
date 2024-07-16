using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.CreateWorld)]
// ReSharper disable once InconsistentNaming
public class CreateWorld_FlecsNet
{
    [Benchmark]
    public void Run()
    {
        var world = World.Create();
        world.Dispose();
    }
}