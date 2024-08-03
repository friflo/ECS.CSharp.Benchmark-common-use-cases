using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_Arch
{
    private World       world;
    private Entity[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

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
            world.Get<Component1>(entity) = new Component1();
        }
    }

    private void Run5Components()
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