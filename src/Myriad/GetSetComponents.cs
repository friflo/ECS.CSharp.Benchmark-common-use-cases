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

        entities = world.CreateEntities(Entities);
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
            entity.GetComponentRef<Component1>() = new Component1();
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities)
        {
            // Get references to all 5 components in one pass
            var (_, c1, c2, c3, c4, c5) = entity.GetComponentRef<Component1, Component2, Component3, Component4, Component5>();

            c1.Ref = new Component1();
            c2.Ref = new Component2();
            c3.Ref = new Component3();
            c4.Ref = new Component4();
            c5.Ref = new Component5();
        }
    }
}