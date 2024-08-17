using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Friflo : AddRemoveComponents
{
    private Entity[] entities;

    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Entities);
    }

    [Benchmark(Baseline = true)]
    public override void Run() => base.Run();

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            entity.AddComponent(new Component1());
        }
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}