using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Arch : GetSetComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
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