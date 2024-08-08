using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_Fennecs : AddRemoveRelations
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void AddRemove1Relation()
    {
        foreach (var entity in entities)
        {
            entity.Add   (Link.With(RelationKey.Key1));
            entity.Remove(Link.With(RelationKey.Key1));
        }
    }

    protected override void AddRemove10Relations()
    {
        foreach (var entity in entities)
        {
            foreach (var key in RelationKey.Keys) {
                entity.Add   (Link.With(key));
            }
            foreach (var key in RelationKey.Keys) {
                entity.Remove(Link.With(key));
            }
        }
    }
}