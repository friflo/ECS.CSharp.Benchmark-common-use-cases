using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.GetSetComponentsT1)]
// ReSharper disable once InconsistentNaming
public class GetSetComponentsT1_Morpeh
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

    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            access.stash1.Get(entity) = new Component1();
        }
    }
}