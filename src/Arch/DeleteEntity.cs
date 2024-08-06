using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Arch : DeleteEntity
{
    private World       world;
    private Entity[]    entities;

    [IterationSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            world.Destroy(entity);
        }
    }
}