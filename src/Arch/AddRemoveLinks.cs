using Arch.Core;
using Arch.Relationships;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Arch : AddRemoveLinks
{
    private World       world;
    private Entity[]    entities;
    private Entity[]    targets;

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Entities).AddComponents();
        targets     = world.CreateEntities(Relations).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities)
        {
            for (int n = 0; n < Relations; n++) {
                entity.AddRelationship(targets[n], new LinkRelation(n));
            }
            foreach (var relation in targets) {
                entity.RemoveRelationship<LinkRelation>(relation);
            }
        }
    }
}