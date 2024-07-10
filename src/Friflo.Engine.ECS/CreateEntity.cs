using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;


[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
[BenchmarkCategory(Category.CreateEntity)]
// ReSharper disable once InconsistentNaming
public class CreateEntity_Friflo
{
    private EntityStore world;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
        world.EnsureCapacity(Constants.CreateEntityCount);
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        world.CreateEntity();
    }
}