using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class QueryT1
{
    private World   world;
    private Query<Component1>   query;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Assert.AreEqual(Constants.EntityCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        query.Each((ref Component1 c1) => {
            c1.Value++;
        });
    }
}