using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class CreateWorld
{
    [Benchmark]
    public void Run()
    {
        var world = new World();
        world.Dispose();
    }
}