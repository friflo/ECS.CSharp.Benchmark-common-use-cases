using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Leopotam : DeleteEntity
{
    private EcsWorld    world;
    private int[]       entities;

    [IterationSetup]
    public void Setup()
    {
        world       = new EcsWorld();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents(world);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            world.DelEntity(entity);
        }
    }
}