using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Morpeh
{
    private World               world;
    private Stash<Component1>   stash1;
    
    [IterationSetup]
    public void Setup()
    {
        world   = World.Create();
        stash1  = world.GetStash<Component1>();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        for (int n = 0; n < Constants.CreateEntityCount; n++)
        {
            var entity = world.CreateEntity();
            stash1.Add(entity);
        }
        world.Commit();
    }
}