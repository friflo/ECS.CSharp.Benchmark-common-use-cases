using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_Myriad
{
    private World       world;
    private Entity[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

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

    [Benchmark]
    public void Run()
    {
        switch (Components) {
            case 1: Run1Component();    return;
            case 5: Run5Components();   return;
        }
    }

    private void Run1Component()
    {
        foreach (var entity in entities)
            entity.GetComponentRef<Component1>(world) = new Component1();
    }

    private void Run5Components()
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