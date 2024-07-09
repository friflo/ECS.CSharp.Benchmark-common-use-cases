using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;


[ShortRunJob]
public class QueryCount
{
    private World   world;
    private QueryDescription queryDescription;
    
    [GlobalSetup]
    public void Setup() {
        world   = World.Create();
        for (int n = 0; n < 10; n++) {
            world.Create().Add(new Position());    
        }
        queryDescription = new QueryDescription().WithAll<Position>();
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