using Arch.Core;
using Arch.Relationships;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Arch
{
    private World       world;
    private Entity[]    entities;
    private Entity[]    targets;
    
    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public  int         RelationCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
        targets     = world.CreateEntities(RelationCount).AddComponents();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities)
        {
            for (int n = 0; n < RelationCount; n++) {
                entity.AddRelationship(targets[n], new LinkRelation(n));
            }
            foreach (var relation in targets) {
                entity.RemoveRelationship<LinkRelation>(relation);
            }
        }
    }
}