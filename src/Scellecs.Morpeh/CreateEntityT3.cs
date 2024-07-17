using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Morpeh
{
    private World world;
    
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
        var stash1 = world.GetStash<Component1>();
        var stash2 = world.GetStash<Component2>();
        var stash3 = world.GetStash<Component3>();
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