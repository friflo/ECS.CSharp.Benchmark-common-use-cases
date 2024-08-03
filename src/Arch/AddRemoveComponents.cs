using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Arch
{
    private World       world;
    private Entity[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
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
        foreach (var entity in entities) {
            world.Add<Component1>(entity);
        }
        foreach (var entity in entities) {
            world.Remove<Component1>(entity);
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            world.Add(entity, new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities) {
            world.Remove<Component1, Component2, Component3, Component4, Component5>(entity);
        }
    }
}