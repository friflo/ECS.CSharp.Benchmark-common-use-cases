using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;

namespace Fennecs;

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