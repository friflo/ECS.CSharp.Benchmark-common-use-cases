using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Arch : QueryComponents
{
    private World               world;
    private QueryDescription    query1Description;
    private QueryDescription    query5Description;
    private Query               query1;
    private Query               query5;
    private ForEach1            forEach1;
    private ForEach5            forEach5;

    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Entities).AddComponents();
        query1Description = new QueryDescription().WithAll<Component1>();
        query5Description = new QueryDescription().WithAll<Component1,Component2,Component3,Component4,Component5>();
        query1 = world.Query(query1Description);
        query5 = world.Query(query5Description);
        Check.AreEqual(Entities, world.CountEntities(query5Description));
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    protected override void Run1Component()
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

    protected override void Run5Components()
    {
        foreach (ref var chunk in query5.GetChunkIterator())
        {
            ref var first = ref chunk.GetFirst<Component1>();
            ref var second = ref chunk.GetFirst<Component2>();
            ref var third = ref chunk.GetFirst<Component3>();
            ref var fourth = ref chunk.GetFirst<Component4>();
            ref var fifth = ref chunk.GetFirst<Component5>();
            foreach (var entity in chunk)
            {
                Unsafe.Add(ref first, entity).Value = Unsafe.Add(ref second, entity).Value +
                                                      Unsafe.Add(ref third, entity).Value +
                                                      Unsafe.Add(ref fourth, entity).Value +
                                                      Unsafe.Add(ref fifth, entity).Value;
            }
        }
    }
}