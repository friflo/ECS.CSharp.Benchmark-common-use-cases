using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Morpeh
{
    private World   world;
    
    [IterationSetup]
    public void Setup()
    {
        world = World.Create();
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
            entity.AddComponent<Component1>();
        }
        world.Commit();
    }
}