using All;
using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class Query1Count
{
    private World   world;
    private QueryDescription queryDescription;
    
    [GlobalSetup]
    public void Setup() {
        world   = World.Create();
        for (int n = 0; n < 10; n++) {
            world.Create().Add(new Component1());    
        }
        queryDescription = new QueryDescription().WithAll<Component1>();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        World.Destroy(world);
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Arch)]
    public void Run() {
        world.CountEntities(queryDescription);
    }
}