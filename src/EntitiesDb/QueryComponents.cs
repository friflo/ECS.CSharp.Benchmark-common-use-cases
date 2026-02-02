using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class QueryComponents_EntitiesDb : QueryComponents
{
    private EntityDatabase db;
    private Query query1;
    private Query query5;

    [GlobalSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        db.CreateEntitiesWithComponents(Entities);
        query1 = db.QueryBuilder.WithAll<Component1>().Build();
        query5 = db.QueryBuilder.WithAll<Component1, Component2, Component3, Component4, Component5>().Build();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        db.Dispose();
    }

    protected override void Run1Component()
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

    protected override void Run5Components()
    {
        foreach (var archetype in query1)
        {
            foreach (ref readonly var chunk in archetype)
            {
                var length = chunk.EntityCount;
                var components1 = chunk.WriteHandle<Component1>();
                var components2 = chunk.WriteHandle<Component2>();
                var components3 = chunk.WriteHandle<Component3>();
                var components4 = chunk.WriteHandle<Component4>();
                var components5 = chunk.WriteHandle<Component5>();
                for (int i = 0; i < length; i++)
                {
                    components1[i].Value =
                        components2[i].Value +
                        components3[i].Value +
                        components4[i].Value +
                        components5[i].Value;
                }
            }
        }
    }
}