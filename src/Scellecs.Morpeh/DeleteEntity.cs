using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Morpeh : DeleteEntity
{
    private World       world;
    private Entity[]    entities;

    [IterationSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Entities).AddComponents(world);
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
        world.Commit();
    }
}