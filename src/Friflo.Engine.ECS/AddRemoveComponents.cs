using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Friflo
{
    private Entity[] entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constants.EntityCount);
    }

    [Benchmark(Baseline = true)]
    public void Run()
    {
        switch (Components) {
            case 1: Run1Component();    return;
            case 5: Run5Components();   return;
        }
    }

    private void Run1Component()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}