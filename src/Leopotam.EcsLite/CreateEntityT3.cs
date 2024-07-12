using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Leopotam
{
    private EcsWorld            world;
    private EcsPool<Component1> ecsPoolC1;
    private EcsPool<Component2> ecsPoolC2;
    private EcsPool<Component3> ecsPoolC3;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EcsWorld();
        ecsPoolC1   = world.GetPool<Component1>();
        ecsPoolC2   = world.GetPool<Component2>();
        ecsPoolC3   = world.GetPool<Component3>();
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
            ecsPoolC2.Add(entity);
            ecsPoolC3.Add(entity);
        }
    }
}