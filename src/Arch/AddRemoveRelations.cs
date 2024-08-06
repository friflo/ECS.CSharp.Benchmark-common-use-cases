using Arch.Core;
using Arch.Relationships;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_Arch : AddRemoveRelations
{
    private World       world;
    private Entity[]    entities;
    private Entity[]    targets;

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    [Benchmark]
    public void Run()
    {
        targets = world.CreateEntities(RelationCount, targets);
        foreach (var entity in entities)
        {
            for (int n = 0; n < RelationCount; n++) {
                entity.AddRelationship(targets[n], new LinkRelation(1337));
            }
            foreach (var relation in targets) {
                entity.RemoveRelationship<LinkRelation>(relation);
            }
        }
        foreach (var target in targets) {
            world.Destroy(target);
        }
    }
}