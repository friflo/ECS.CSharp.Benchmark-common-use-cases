using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_DefaultEcs
{
    private World world;
    
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
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.CreateEntity();
            entity.Set<Component1>();
            entity.Set<Component2>();
            entity.Set<Component3>();
        }
    }
}