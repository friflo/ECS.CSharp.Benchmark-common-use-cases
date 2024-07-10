using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.Types;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Arch;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class QueryT1
{
    private World   world;
    private Query   query;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        world   = World.Create();
        for (int n = 0; n < EntityCount; n++) {
            var entity = world.Create();
            entity.Add(new Component1());
        }
        var queryDescription = new QueryDescription().WithAll<Component1>();
        query = world.Query(in queryDescription);
        Assert.AreEqual(EntityCount, world.CountEntities(queryDescription));
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        World.Destroy(world);
    }
    
    [Benchmark]
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