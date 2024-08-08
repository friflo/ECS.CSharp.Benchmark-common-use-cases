using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_Myriad : QueryFragmented
{
    private World world;
    private QueryDescription query;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        // Create all the entities using a command buffer
        var cmd = new CommandBuffer(world);
        for (var i = 0; i < Entities; i++)
        {
            var entity = cmd.Create();

            entity.Set(new Component1());

            if ((i & 1) != 0) entity.Set<Component2>(default);
            if ((i & 2) != 0) entity.Set<Component3>(default);
            if ((i & 4) != 0) entity.Set<Component4>(default);
            if ((i & 8) != 0) entity.Set<Component5>(default);
        }

        cmd.Playback().Dispose();

        query = new QueryBuilder().Include<Component1>().Build(world);
        if (query.Count() != Entities)
            throw new Exception("Setup failed to create correct number of entities (Myriad bug?)");
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
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