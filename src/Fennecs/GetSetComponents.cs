using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Fennecs : GetSetComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            entity.Ref<Component1>() = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Ref<Component1>() = new Component1();
            entity.Ref<Component2>() = new Component2();
            entity.Ref<Component3>() = new Component3();
            entity.Ref<Component4>() = new Component4();
            entity.Ref<Component5>() = new Component5();
        }
    }
}