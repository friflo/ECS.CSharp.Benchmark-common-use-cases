using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.AddRemoveComponentsT1)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT1_Friflo
{
    private Entity[] entities;
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constants.EntityCount);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
        }
    }
}