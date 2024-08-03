using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Fennecs
{
    private World       world;
    private Entity[]    entities;

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
            entity.Add(new Component1());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
            entity.Add(new Component2());
            entity.Add(new Component3());
            entity.Add(new Component4());
            entity.Add(new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1>();
            entity.Remove<Component2>();
            entity.Remove<Component3>();
            entity.Remove<Component4>();
            entity.Remove<Component5>();
        }
    }
}