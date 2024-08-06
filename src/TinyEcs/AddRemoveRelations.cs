using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_TinyEcs : AddRemoveRelations
{
    private World           world;
    private EntityView[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void AddRemove1Relation()
    {
        foreach (var entity in entities)
        {
            entity.Set<Tag1, Relation>(new Relation(1337));
            entity.Unset<Tag1, Relation>();
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

            entity.Unset<Tag1,  Relation>();
            entity.Unset<Tag2,  Relation>();
            entity.Unset<Tag3,  Relation>();
            entity.Unset<Tag4,  Relation>();
            entity.Unset<Tag5,  Relation>();
            entity.Unset<Tag6,  Relation>();
            entity.Unset<Tag7,  Relation>();
            entity.Unset<Tag8,  Relation>();
            entity.Unset<Tag9,  Relation>();
            entity.Unset<Tag10, Relation>();
        }
    }
}