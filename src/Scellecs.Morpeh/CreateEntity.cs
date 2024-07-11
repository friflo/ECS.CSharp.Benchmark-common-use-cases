using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
[BenchmarkCategory(Category.CreateEntity)]
// ReSharper disable once InconsistentNaming
public class CreateEntity_Morpeh
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
        world.CreateEntity();
        world.Commit();
    }
}