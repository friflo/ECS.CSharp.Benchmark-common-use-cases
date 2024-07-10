using BenchmarkDotNet.Attributes;

namespace fennecs;

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