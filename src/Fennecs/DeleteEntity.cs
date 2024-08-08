using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Fennecs : DeleteEntity
{
    private World       world;
    private Entity[]    entities;

    [IterationSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            entity.Despawn();
        }
    }
}