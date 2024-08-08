using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Myriad : QueryComponents
{
    private World               world;
    private QueryDescription    query1;
    private QueryDescription    query5;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        var entities = world.CreateEntities(Entities);
        entities.AddComponents(world);

        query1 = new QueryBuilder().Include<Component1>().Build(world);
        query5 = new QueryBuilder().Include<Component1, Component2, Component3, Component4, Component5>().Build(world);
        if (query5.Count() != Entities)
            throw new Exception("Setup failed to create correct number of entities (Myriad bug?)");
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        world.Execute<IncrementComponent1, Component1>(query1);
    }

    protected override void Run5Components()
    {
        world.Execute<Add5Components, Component1, Component2, Component3, Component4, Component5>(query5);
    }
}

internal readonly struct IncrementComponent1
    : IQuery1<Component1>
{
    public void Execute(Entity e, ref Component1 t0)
    {
        t0.Value++;
    }
}

internal readonly struct Add5Components
    : IQuery5<Component1, Component2, Component3, Component4, Component5>
{
    public void Execute(Entity e, ref Component1 c1, ref Component2 c2, ref Component3 c3, ref Component4 c4, ref Component5 c5)
    {
        c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;
    }
}