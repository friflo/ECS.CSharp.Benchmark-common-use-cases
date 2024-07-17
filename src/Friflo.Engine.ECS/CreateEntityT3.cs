using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Friflo
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
        var archetype3 = world.GetArchetype(ComponentTypes.Get<Component1,Component2,Component3>());
        archetype3.CreateEntities(Constants.CreateEntityCount);
    }
}