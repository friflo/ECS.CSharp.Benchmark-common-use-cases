using BenchmarkDotNet.Attributes;
using Frent.Core;

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
        foreach (var entity in entities)
        {
            entity.Add<Component1, Component2, Component3, Component4, Component5>(default, default, default, default, default);
        }
        foreach (var entity in entities)
        {
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}