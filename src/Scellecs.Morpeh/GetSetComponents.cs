using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_Morpeh
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
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents(world);
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
            access.stash1.Get(entity) = new Component1();
        }
    }

    private void Run5Components()
    {
        foreach (var entity in entities) {
            access.stash1.Get(entity) = new Component1();
            access.stash2.Get(entity) = new Component2();
            access.stash3.Get(entity) = new Component3();
            access.stash4.Get(entity) = new Component4();
            access.stash5.Get(entity) = new Component5();
        }
    }
}