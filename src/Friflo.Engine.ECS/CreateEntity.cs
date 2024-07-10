using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Friflo.Engine.ECS;


[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
public class CreateEntity
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