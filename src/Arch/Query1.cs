using System.Runtime.CompilerServices;
using All;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.Types;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class Query1
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup() {
        world   = World.Create();
        for (int n = 0; n < 10; n++) {
            world.Create().Add(new Component1());    
        }
        var queryDescription = new QueryDescription().WithAll<Component1>();
        query = world.Query(in queryDescription);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        World.Destroy(world);
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Arch)]
    public void Run()
    {
        foreach(ref var chunk in query.GetChunkIterator())
        {
            var components = chunk.GetFirst<Component1>;    // chunk.GetArray, chunk.GetSpan...
            foreach(var entity in chunk)                    // Iterate over each row/entity inside chunk
            {
                ref var _ = ref Unsafe.Add(ref components, entity);
            }
        }
    }
}