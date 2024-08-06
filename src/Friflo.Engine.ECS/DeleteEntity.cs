using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Friflo : DeleteEntity
{
    private EntityStore world;
    private Entity[]    entities;

    [IterationSetup]
    public void Setup()
    {
        world       = new EntityStore { RecycleIds = false };
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }

    [Benchmark(Baseline = true)]
    public override void Run()
    {
        foreach (var entity in entities) {
            entity.DeleteEntity();
        }
    }
}