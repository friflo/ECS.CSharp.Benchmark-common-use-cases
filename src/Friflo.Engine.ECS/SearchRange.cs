using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class SearchRange_Friflo : SearchRange
{
    private EntityStore world;

    [GlobalSetup]
    public void Setup()
    {
        world           = new EntityStore();
        var entities    = world.CreateEntities(Entities);
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
            var min = searchValue * 100;
            var max = searchValue * 100 + 99;
            var result = world.Query().ValueInRange<SearchableComponent,int>(min, max);
            Check.AreEqual(100, result.Count);
        }
    }
}