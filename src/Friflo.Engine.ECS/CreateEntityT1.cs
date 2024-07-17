using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Friflo
{
    private EntityStore world;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        var archetype1 = world.GetArchetype(ComponentTypes.Get<Component1>());
        archetype1.CreateEntities(Constants.CreateEntityCount);
    }
}