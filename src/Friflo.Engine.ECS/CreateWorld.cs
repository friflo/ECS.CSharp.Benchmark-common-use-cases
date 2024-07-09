using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class CreateWorld
{
    [GlobalSetup]
    public void Setup() { }
    
    [GlobalCleanup]
    public void Shutdown() {
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Arch)]
    public void Run()
    {
        _ = new EntityStore();
        // nothing to Dispose() - has no unmanaged resources
    }
}