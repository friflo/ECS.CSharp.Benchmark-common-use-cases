using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_DefaultEcs : DeleteEntity
{
    private World       world;
    private Entity[]    entities;

    [IterationSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
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
            entity.Dispose();
        }
    }
}