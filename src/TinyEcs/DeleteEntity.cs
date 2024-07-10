using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[InvocationCount(Constant.DeleteEntityCount)]
[IterationCount(Constant.DeleteEntityIterationCount)]
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
        entities    = world.CreateEntities(Constant.DeleteEntityCount);
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