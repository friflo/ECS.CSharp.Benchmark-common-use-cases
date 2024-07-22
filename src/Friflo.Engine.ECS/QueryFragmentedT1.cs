using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_Friflo
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        query = world.Query<Component1>();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n]; 
                                entity.AddComponent<Component1>();
            if ((n &   1) != 0) entity.AddComponent<Component2>();
            if ((n &   2) != 0) entity.AddComponent<Component3>();
            if ((n &   4) != 0) entity.AddComponent<Component4>();
            if ((n &   8) != 0) entity.AddComponent<Component5>();
        }
        Check.AreEqual(Constants.FragmentationCount, query.Count);
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