using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[InvocationCount(Constants.DeleteEntityCount)]
[IterationCount(Constants.DeleteEntityIterationCount)]
[ShortRunJob]
public class DeleteEntity
{
    private EcsWorld    world;
    private int[]       entities;
    private int         entityIndex;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EcsWorld();
        entities    = world.CreateEntities(Constants.DeleteEntityCount);
        entityIndex = 0;
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        world.DelEntity(entities[entityIndex++]);
    }
}