using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Arch
{
    private World       world;
    private Entity[]    entities;
    
    [IterationSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            world.Destroy(entity);
        }
    }
}