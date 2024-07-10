using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
[BenchmarkCategory(Category.CreateEntity)]
// ReSharper disable once InconsistentNaming
public class CreateEntity_Leopotam
{
    private EcsWorld    world;
    
    [IterationSetup]
    public void Setup()
    {
        world = new EcsWorld();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        world.NewEntity();
    }
}