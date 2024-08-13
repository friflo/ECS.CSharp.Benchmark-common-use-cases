using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_Arch : QueryFragmented
{
    private World               world;
    private QueryDescription    queryDescription;
    private ForEach1            forEach;
    private Query               query1;

    [GlobalSetup]
    public void Setup()
    {
        world   = World.Create();
        var entities = world.CreateEntities(Entities);
        for (int n = 0; n < Entities; n++) {
            var entity = entities[n];
                                entity.Add<Component1>();
            if ((n &   1) != 0) entity.Add<Component2>();
            if ((n &   2) != 0) entity.Add<Component3>();
            if ((n &   4) != 0) entity.Add<Component4>();
            if ((n &   8) != 0) entity.Add<Component5>();
        }
        queryDescription = new QueryDescription().WithAll<Component1>();
        query1 = world.Query(queryDescription);
        Check.AreEqual(Entities, world.CountEntities(queryDescription));
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    [Benchmark]
    public override void Run()
    {
        foreach (ref var chunk in query1.GetChunkIterator())
        {
            ref var first = ref chunk.GetFirst<Component1>();
            foreach (var entity in chunk)
            {
                Unsafe.Add(ref first, entity).Value++;
            }
        }
    }
}