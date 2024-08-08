using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_TinyEcs : GetSetComponents
{
    private World           world;
    private EntityView[]    entities;

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
            world.Get<Component1>(entity) = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            world.Get<Component1>(entity) = new Component1();
            world.Get<Component2>(entity) = new Component2();
            world.Get<Component3>(entity) = new Component3();
            world.Get<Component4>(entity) = new Component4();
            world.Get<Component5>(entity) = new Component5();
        }
    }
}