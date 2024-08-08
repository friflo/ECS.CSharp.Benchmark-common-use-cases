using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemove_Morpeh : CommandBufferAddRemove
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Entities);
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
        }
        world.Commit(); // Apply changes 1

        foreach (var entity in entities) {
            entity.RemoveComponent<Component1>();
            entity.RemoveComponent<Component2>();
        }
        world.Commit(); // Apply changes 2
    }
}