using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Myriad : GetSetComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        entities = world.CreateEntities(Constants.EntityCount);
        entities.AddComponents(world);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities)
            entity.GetComponentRef<Component1>(world) = new Component1();
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.GetComponentRef<Component1>(world) = new Component1();
            entity.GetComponentRef<Component2>(world) = new Component2();
            entity.GetComponentRef<Component3>(world) = new Component3();
            entity.GetComponentRef<Component4>(world) = new Component4();
            entity.GetComponentRef<Component5>(world) = new Component5();
        }
    }
}