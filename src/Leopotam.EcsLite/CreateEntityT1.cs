using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Leopotam
{
    private EcsWorld            world;
    private EcsPool<Component1> ecsPoolC1;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EcsWorld();
        ecsPoolC1   = world.GetPool<Component1>();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.NewEntity();
            ecsPoolC1.Add(entity);
        }
    }
}