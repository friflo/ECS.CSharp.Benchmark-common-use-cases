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
        world.Entity()
            .Add(new Component1())
            .Add(new Component2())
            .Add(new Component3())
            .Spawn(Constants.CreateEntityCount);
    }
}