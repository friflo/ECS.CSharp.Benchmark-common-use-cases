using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Myriad
{
    private World world;
    private QueryDescription query;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        var entities = world.CreateEntities(Constants.EntityCount);
        entities.AddComponents(world);

        query = new QueryBuilder().Include<Component1, Component2, Component3, Component4, Component5>().Build(world);
        if (query.Count() != Constants.EntityCount)
            throw new Exception("Setup failed to create correct number of entities (Myriad bug?)");
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public void Run()
    {
        world.Execute<AddComponents, Component1, Component2, Component3, Component4, Component5>(query);
    }

    private readonly struct AddComponents
        : IQuery5<Component1, Component2, Component3, Component4, Component5>
    {
        public void Execute(Entity e, ref Component1 c1, ref Component2 c2, ref Component3 c3, ref Component4 c4, ref Component5 c5)
        {
            c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;
        }
    }
}