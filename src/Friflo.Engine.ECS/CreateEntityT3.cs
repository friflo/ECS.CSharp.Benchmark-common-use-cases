using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Friflo
{
    private EntityStore world;
    private Archetype   archetype3;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
        world.EnsureCapacity(Constants.CreateEntityCount);
        archetype3 = world.GetArchetype(ComponentTypes.Get<Component1,Component2,Component3>());
        archetype3.EnsureCapacity(Constants.CreateEntityCount);
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            archetype3.CreateEntity();
        }
    }
}