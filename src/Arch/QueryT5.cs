using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Arch
{
    private World               world;
    private QueryDescription    queryDescription;
    private ForEach5            forEach;
    
    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        queryDescription = new QueryDescription().WithAll<Component1,Component2,Component3,Component4,Component5>();

        Assert.AreEqual(Constants.EntityCount, world.CountEntities(queryDescription));
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        world.InlineQuery<ForEach5, Component1,Component2,Component3,Component4,Component5>(queryDescription, ref forEach);
    }
}