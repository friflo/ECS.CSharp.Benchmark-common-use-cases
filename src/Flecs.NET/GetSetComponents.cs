using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_FlecsNet
{
    private World       world;
    private Entity[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
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
        foreach (var entity in entities) {
            entity.GetMut<Component1>() = new Component1();
        }
    }

    private void Run5Components()
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