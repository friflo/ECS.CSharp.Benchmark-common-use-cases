using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Fennecs
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
            entity.Add<Component2>();
            entity.Add<Component3>();
        }
    }
}