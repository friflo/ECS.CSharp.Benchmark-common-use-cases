using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Friflo
{
    private EntityStore world;
    private Archetype   archetype1;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
        archetype1 = world.GetArchetype(ComponentTypes.Get<Component1>());
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        archetype1.CreateEntities(Constants.CreateEntityCount);
    }
}