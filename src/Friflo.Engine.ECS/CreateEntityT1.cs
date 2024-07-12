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
        world.EnsureCapacity(Constants.CreateEntityCount);
        archetype1 = world.GetArchetype(ComponentTypes.Get<Component1>());
        archetype1.EnsureCapacity(Constants.CreateEntityCount);
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
            archetype1.CreateEntity();
        }
    }
}