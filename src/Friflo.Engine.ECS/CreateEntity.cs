using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Friflo.Engine.ECS;


[InvocationCount(Constant.CreateEntityCount)]
[IterationCount(Constant.CreateEntityIterationCount)]
[ShortRunJob]
public class CreateEntity
{
    private EntityStore world;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
        world.EnsureCapacity(Constant.CreateEntityCount);
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