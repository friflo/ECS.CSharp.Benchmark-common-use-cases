using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class CreateWorld
{
    [GlobalSetup]
    public void Setup() { }
    
    [GlobalCleanup]
    public void Shutdown() { }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Arch)]
    public void Run()
    {
        var world = World.Create();
        World.Destroy(world);
    }
}