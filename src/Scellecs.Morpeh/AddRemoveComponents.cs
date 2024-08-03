using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.AddRemoveComponents)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Morpeh
{
    private World       world;
    private Entity[]    entities;
    private Access      access;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        access      = new Access(world);
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
            access.stash1.Add(entity, new Component1());
        }
        foreach (var entity in entities) {
            access.stash1.Remove(entity);
        }
        world.Commit();
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            access.stash1.Add(entity, new Component1());
            access.stash2.Add(entity, new Component2());
            access.stash3.Add(entity, new Component3());
            access.stash4.Add(entity, new Component4());
            access.stash5.Add(entity, new Component5());
        }
        foreach (var entity in entities) {
            access.stash1.Remove(entity);
            access.stash2.Remove(entity);
            access.stash3.Remove(entity);
            access.stash4.Remove(entity);
            access.stash5.Remove(entity);
        }
        world.Commit();
    }
}