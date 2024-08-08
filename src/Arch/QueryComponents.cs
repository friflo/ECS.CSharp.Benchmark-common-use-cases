using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Arch : QueryComponents
{
    private World               world;
    private QueryDescription    query1Description;
    private QueryDescription    query5Description;
    private ForEach1            forEach1;
    private ForEach5            forEach5;

    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Entities).AddComponents();
        query1Description = new QueryDescription().WithAll<Component1>();
        query5Description = new QueryDescription().WithAll<Component1,Component2,Component3,Component4,Component5>();

        Check.AreEqual(Entities, world.CountEntities(query5Description));
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    protected override void Run1Component()
    {
        world.InlineQuery<ForEach1, Component1>(query1Description, ref forEach1);
    }

    protected override void Run5Components()
    {
        world.InlineQuery<ForEach5, Component1,Component2,Component3,Component4,Component5>(query5Description, ref forEach5);
    }
}