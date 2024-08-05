using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Morpeh : GetSetComponents
{
    private World       world;
    private Entity[]    entities;
    private Access      access;

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

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            access.stash1.Get(entity) = new Component1();
        }
    }

    protected override void Run5Components()
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