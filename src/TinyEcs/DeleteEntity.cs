using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_TinyEcs : DeleteEntity
{
    private World           world;
    private EntityView[]    entities;

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
            entity.Delete();
        }
    }
}