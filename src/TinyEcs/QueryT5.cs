using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[ShortRunJob]
public class QueryT5
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        query = world.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
        Assert.AreEqual(Constant.EntityCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        query.Each((ref Component1 c1, ref Component2 c2, ref Component3 c3, ref Component4 c4, ref Component5 c5) => {
            c1.value = c2.value + c3.value + c4.value + c5.value;        
        });
    }
}