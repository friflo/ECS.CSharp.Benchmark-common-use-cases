using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class QueryT5
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        var queryDescription = new QueryDescription().WithAll<Component1,Component2,Component3,Component4,Component5>();
        query = world.Query(in queryDescription);
        Assert.AreEqual(Constant.EntityCount, world.CountEntities(queryDescription));
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    // [Benchmark]
    public void Run()
    {
        foreach(ref var chunk in query.GetChunkIterator())
        {
            /* ???
            var components1 = chunk.GetFirst<Component1>;
            var components2 = chunk.GetFirst<Component2>;
            var components3 = chunk.GetFirst<Component3>;
            var components4 = chunk.GetFirst<Component4>;
            var components5 = chunk.GetFirst<Component5>;
            foreach(var entity in chunk)                    // Iterate over each row/entity inside chunk
            {
                ref Component1 c1 = ref Unsafe.Add(ref components1, entity);
                ref var c2 = ref Unsafe.Add(ref components2, entity);
                ref var c3 = ref Unsafe.Add(ref components3, entity);
                ref var c4 = ref Unsafe.Add(ref components4, entity);
                ref var c5 = ref Unsafe.Add(ref components5, entity);
                c1.value = c2.value;
            }
            */
        }
    }
}