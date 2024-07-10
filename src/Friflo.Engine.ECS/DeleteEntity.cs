using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Friflo.Engine.ECS;


[InvocationCount(Constant.DeleteEntityCount)]
[IterationCount(Constant.DeleteEntityIterationCount)]
[ShortRunJob]
public class DeleteEntity
{
    private EntityStore world;
    private Entity[]    entities;
    private int         entityIndex;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EntityStore();
        entities    = world.CreateEntities(Constant.DeleteEntityCount);
        entityIndex = 0;
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        entities[entityIndex++].DeleteEntity();
    }
}