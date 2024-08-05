using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_FlecsNet : GetSetComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            entity.GetMut<Component1>() = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.GetMut<Component1>() = new Component1();
            entity.GetMut<Component2>() = new Component2();
            entity.GetMut<Component3>() = new Component3();
            entity.GetMut<Component4>() = new Component4();
            entity.GetMut<Component5>() = new Component5();
        }
    }

}