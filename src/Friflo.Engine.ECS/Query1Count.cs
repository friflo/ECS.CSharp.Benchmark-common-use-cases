using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class Query1Count
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        for (int n = 0; n < 10; n++) {
            world.CreateEntity();
        }
        query = world.Query<Component1>();
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Friflo)]
    public void Run() {
        _ = query.Count;
    }
}