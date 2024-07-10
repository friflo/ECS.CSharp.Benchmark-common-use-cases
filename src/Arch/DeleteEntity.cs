    using Arch.Core;
    using Arch.Core.Extensions.Dangerous;
    using BenchmarkDotNet.Attributes;

namespace Arch;

[InvocationCount(Constants.DeleteEntityCount)]
[IterationCount(Constants.DeleteEntityIterationCount)]
[ShortRunJob]
public class DeleteEntity
{
    private World       world;
    private Entity[]    entities;
    private int         entityIndex;
    
    [IterationSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.DeleteEntityCount);
        entityIndex = 0;
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        world.Destroy( entities[entityIndex++]);
    }
}