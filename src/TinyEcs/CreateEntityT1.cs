using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_TinyEcs
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
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            var entity = world.Entity();
            entity.Set<Component1>();
        }
    }
}