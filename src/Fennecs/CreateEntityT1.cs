using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Fennecs
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
            var entity = world.Spawn();
            entity.Add<Component1>();
        }
    }
}