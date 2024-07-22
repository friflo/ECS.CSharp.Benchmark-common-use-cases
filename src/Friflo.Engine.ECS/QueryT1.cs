using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_Friflo
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Check.AreEqual(Constants.EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var (components, _) in query.Chunks) {
            foreach (ref var component in components.Span) {
                component.Value++;
            }
        }
    }
}