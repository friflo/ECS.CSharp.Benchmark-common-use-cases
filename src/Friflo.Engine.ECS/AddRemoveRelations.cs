using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_Friflo : AddRemoveRelations
{
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }

    [Benchmark(Baseline = true)]
    public void Run()
    {
        if (RelationCount == 1) {
            AddRemove1Relation();
            return;
        }
        AddRemove10Relations();
    }

    private void AddRemove1Relation()
    {
        foreach (var entity in entities)
        {
            entity.AddRelation(new Relation(RelationKey.Key1, 1337));
            entity.RemoveRelation<Relation, RelationKey>(RelationKey.Key1);
        }
    }

    private static readonly RelationKey[] Keys = Enum.GetValues(typeof(RelationKey)).Cast<RelationKey>().ToArray();

    private void AddRemove10Relations()
    {
        foreach (var entity in entities)
        {
            foreach (var key in Keys) {
                entity.AddRelation(new Relation(key, 1337));
                // Assert.AreEqual(1337, entity.GetRelation<Relation, RelationKey>(key).Value); // O(1)
            }
            //  Assert.AreEqual(RelationCount, entity.GetRelations<Relation>().Length);         // O(1)
            foreach (var key in Keys) {
                entity.RemoveRelation<Relation, RelationKey>(key);
            }
        }
    }
}