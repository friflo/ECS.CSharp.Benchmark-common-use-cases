using BenchmarkDotNet.Attributes;

namespace fennecs;

[InvocationCount(Constant.CreateEntityCount)]
[IterationCount(Constant.CreateEntityIterationCount)]
[ShortRunJob]
public class CreateEntity
{
    private World   world;
    
    [IterationSetup]
    public void Setup()
    {
        world = new World();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        world.Spawn();
    }
}