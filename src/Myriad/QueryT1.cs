using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_Myriad
{
    private World world;
    private QueryDescription query;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        var entities = world.CreateEntities(Constants.EntityCount);
        entities.AddComponents(world);

        query = new QueryBuilder().Include<Component1>().Build(world);
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
        world.Execute<IncrementComponent1, Component1>(query);
    }

    private readonly struct IncrementComponent1
        : IQuery1<Component1>
    {
        public void Execute(Entity e, ref Component1 t0)
        {
            t0.Value++;
        }
    }
}