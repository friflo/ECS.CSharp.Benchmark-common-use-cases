using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[InvocationCount(Constants.DeleteEntityCount)]
[IterationCount(Constants.DeleteEntityIterationCount)]
[ShortRunJob]
public class DeleteEntity
{
    private World           world;
    private EntityView[]    entities;
    private int             entityIndex;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Constants.DeleteEntityCount);
        entityIndex = 0;
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        entities[entityIndex++].Delete();
    }
}