using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Morpeh
{
    private World               world;
    private Stash<Component1>   stash1;
    private Stash<Component2>   stash2;
    private Stash<Component3>   stash3;
    
    [IterationSetup]
    public void Setup()
    {
        world   = World.Create();
        stash1  = world.GetStash<Component1>();
        stash2  = world.GetStash<Component2>();
        stash3  = world.GetStash<Component3>();
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
            stash2.Add(entity);
            stash3.Add(entity);
        }
        world.Commit();
    }
}