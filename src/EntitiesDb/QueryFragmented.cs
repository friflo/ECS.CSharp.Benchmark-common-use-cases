using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class QueryFragmented_EntitiesDb : QueryFragmented
{
    private EntityDatabase db;
    private Query query1;

    [GlobalSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        var entities = db.CreateEntities(Entities);
        for (int n = 0; n < Entities; n++)
        {
            var entity = entities[n];
            db.Add(entity, new Component1());
            if ((n & 1) != 0) db.Add(entity, new Component2());
            if ((n & 2) != 0) db.Add(entity, new Component3());
            if ((n & 4) != 0) db.Add(entity, new Component4());
            if ((n & 8) != 0) db.Add(entity, new Component5());
        }
        query1 = db.QueryBuilder.WithAll<Component1>().Build();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var archetype in query1)
        {
            foreach (ref readonly var chunk in archetype)
            {
                var length = chunk.EntityCount;
                var components1 = chunk.WriteHandle<Component1>();
                for (int i = 0; i < length; i++)
                {
                    components1[i].Value++;
                }
            }
        }
    }
}
