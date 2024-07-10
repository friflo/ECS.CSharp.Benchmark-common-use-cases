using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class QueryT1
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Assert.AreEqual(Constants.EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var (components, _) in query.Chunks) {
            foreach (ref var component in components.Span) {
                component.value++;
            }
        }
    }
}