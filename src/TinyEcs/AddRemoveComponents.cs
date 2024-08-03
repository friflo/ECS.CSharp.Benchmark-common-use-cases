using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_TinyEcs
{
    private World           world;
    private EntityView[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constants.EntityCount);
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
            entity.Set(new Component1());
        }
        foreach (var entity in entities) {
            entity.Unset<Component1>();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Set(new Component1());
            entity.Set(new Component2());
            entity.Set(new Component3());
            entity.Set(new Component4());
            entity.Set(new Component5());
        }
        foreach (var entity in entities) {
            entity.Unset<Component1>();
            entity.Unset<Component2>();
            entity.Unset<Component3>();
            entity.Unset<Component4>();
            entity.Unset<Component5>();
        }
    }
}