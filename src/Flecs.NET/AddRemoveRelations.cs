using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_FlecsNet : AddRemoveRelations
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void AddRemove1Relation()
    {
        foreach (var entity in entities)
        {
            entity.Set<Tag1, Relation>(new Relation(1337));
            entity.Remove<Tag1, Relation>();
        }
    }

    protected override void AddRemove10Relations()
    {
        foreach (var entity in entities)
        {
            entity.Set<Tag1,  Relation>(new Relation(1337));
            entity.Set<Tag2,  Relation>(new Relation(1337));
            entity.Set<Tag3,  Relation>(new Relation(1337));
            entity.Set<Tag4,  Relation>(new Relation(1337));
            entity.Set<Tag5,  Relation>(new Relation(1337));
            entity.Set<Tag6,  Relation>(new Relation(1337));
            entity.Set<Tag7,  Relation>(new Relation(1337));
            entity.Set<Tag8,  Relation>(new Relation(1337));
            entity.Set<Tag9,  Relation>(new Relation(1337));
            entity.Set<Tag10, Relation>(new Relation(1337));

            entity.Remove<Tag1,  Relation>();
            entity.Remove<Tag2,  Relation>();
            entity.Remove<Tag3,  Relation>();
            entity.Remove<Tag4,  Relation>();
            entity.Remove<Tag5,  Relation>();
            entity.Remove<Tag6,  Relation>();
            entity.Remove<Tag7,  Relation>();
            entity.Remove<Tag8,  Relation>();
            entity.Remove<Tag9,  Relation>();
            entity.Remove<Tag10, Relation>();
        }
    }
}