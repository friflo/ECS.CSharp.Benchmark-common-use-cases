using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Leopotam
{
    private EcsWorld world;
    
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
        var ecsPoolC1 = world.GetPool<Component1>();
        var ecsPoolC2 = world.GetPool<Component2>();
        var ecsPoolC3 = world.GetPool<Component3>();
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.NewEntity();
            ecsPoolC1.Add(entity);
            ecsPoolC2.Add(entity);
            ecsPoolC3.Add(entity);
        }
    }
}