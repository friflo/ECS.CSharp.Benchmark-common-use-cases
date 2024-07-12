using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;


[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Friflo
{
    private EntityStore world;
    private Entity[]    entities;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EntityStore();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.DeleteEntity();
        }
    }
}