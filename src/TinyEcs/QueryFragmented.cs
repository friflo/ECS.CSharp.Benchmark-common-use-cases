using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_TinyEcs : QueryFragmented
{
    private World   world;
    private Query   query;

    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        var entities = world.CreateEntities(Entities);
        query = world.QueryBuilder().With<Component1>().Build();
        for (int n = 0; n < Entities; n++) {
            var entity = entities[n];
                                entity.Set(new Component1());
            if ((n &   1) != 0) entity.Set(new Component2());
            if ((n &   2) != 0) entity.Set(new Component3());
            if ((n &   4) != 0) entity.Set(new Component4());
            if ((n &   8) != 0) entity.Set(new Component5());
        }
        Check.AreEqual(Entities, query.Count());
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var (e, c1) in query.Iter<Component1>()) {
            for (var n = 0; n < e.Length; n++) {
                c1[n].Value++;
            }
        }
    }
}