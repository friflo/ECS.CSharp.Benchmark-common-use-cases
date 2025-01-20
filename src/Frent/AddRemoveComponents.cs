using BenchmarkDotNet.Attributes;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Frent : AddRemoveComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Entities);
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override  void Run1Component()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
        }
    }

    protected override  void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
            entity.Add(new Component2());
            entity.Add(new Component3());
            entity.Add(new Component4());
            entity.Add(new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
            entity.Remove<Component2>();
            entity.Remove<Component3>();
            entity.Remove<Component4>();
            entity.Remove<Component5>();
        }
    }
}