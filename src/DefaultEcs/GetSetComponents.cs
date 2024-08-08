using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_DefaultEcs : GetSetComponents
{
    private World       world;
    private Entity[]    entities;


    [GlobalSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            entity.Get<Component1>() = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Get<Component1>() = new Component1();
            entity.Get<Component2>() = new Component2();
            entity.Get<Component3>() = new Component3();
            entity.Get<Component4>() = new Component4();
            entity.Get<Component5>() = new Component5();
        }
    }
}