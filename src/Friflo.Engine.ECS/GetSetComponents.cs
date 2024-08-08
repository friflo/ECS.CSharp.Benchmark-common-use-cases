using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Friflo : GetSetComponents
{
    private Entity[] entities;

    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [Benchmark(Baseline = true)]
    public override void Run() => base.Run();

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            entity.GetComponent<Component1>() = new Component1();
        }
    }

    protected override void Run5Components()
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