using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Morpeh
{
    private World       world;
    private Entity[]    entities;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
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
            entity.AddComponent<Component1>();
        }
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
        }
        world.Commit();
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
            entity.RemoveComponent<Component2>();
            entity.RemoveComponent<Component3>();
            entity.RemoveComponent<Component4>();
            entity.RemoveComponent<Component5>();
        }
        world.Commit();
    }
}