using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[BenchmarkCategory(Category.SearchRange)]
// ReSharper disable once InconsistentNaming
public class SearchRange_Friflo
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
    public void Run()
    {
        for (int searchValue = 0; searchValue < Constants.SearchCount; searchValue++)
        {
            var min = searchValue * 100;
            var max = searchValue * 100 + 99;
            var result = world.Query().ValueInRange<SearchableComponent,int>(min, max);
            Assert.AreEqual(100, result.Count);
        }
    }
}