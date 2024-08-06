using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class SearchComponentField_Friflo : SearchComponentField
{
    private EntityStore world;

    [GlobalSetup]
    public void Setup()
    {
        world           = new EntityStore();
        var entities    = world.CreateEntities(Constants.SearchSetSize);
        // add a component to every entity that can be searched
        for (int value = 0; value < entities.Length; value++) {
            entities[value].AddComponent(new SearchableComponent(value));
        }
    }

    [Benchmark(Baseline = true)]
    public override void Run()
    {
        for (int searchValue = 0; searchValue < Constants.SearchCount; searchValue++)
        {
            var result = world.GetEntitiesWithComponentValue<SearchableComponent,int>(searchValue);
            Check.AreEqual(1, result.Count);
        }
    }
}