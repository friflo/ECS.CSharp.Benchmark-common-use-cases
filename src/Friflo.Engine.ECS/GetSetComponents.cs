using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_Friflo
{
    private Entity[] entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
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
            entity.GetComponent<Component1>() = new Component1();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            var data = entity.Data;
            data.Get<Component1>() = new Component1();
            data.Get<Component2>() = new Component2();
            data.Get<Component3>() = new Component3();
            data.Get<Component4>() = new Component4();
            data.Get<Component5>() = new Component5();
        }
    }
}