using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_TinyEcs
{
    private World           world;
    private EntityView[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup() {
        world       = new World();
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
            entity.Get<Component1>() = new Component1();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Get<Component1>() = new Component1();
            entity.Get<Component2>() = new Component2();
            entity.Get<Component3>() = new Component3();
            entity.Get<Component4>() = new Component4();
            entity.Get<Component5>() = new Component5();
        }
    }
}