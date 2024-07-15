using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveRelations)]
// ReSharper disable once InconsistentNaming
public class AddRemoveRelations_Fennecs
{
    private World       world;
    private Entity[]    entities;
    [Params(Constants.RelationCountP1, Constants.RelationCountP2)]
    public  int         RelationCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constants.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    [Benchmark]
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
            entity.Add   (Link.With(RelationKey.Key1));
            entity.Remove(Link.With(RelationKey.Key1));
        }
    }
    
    private void AddRemove10Relations()
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