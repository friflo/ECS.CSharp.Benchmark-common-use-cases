using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class CreateWorld
{
    [Benchmark]
    public void Run()
    {
        var world = new EcsWorld();
        world.Destroy();
    }
}