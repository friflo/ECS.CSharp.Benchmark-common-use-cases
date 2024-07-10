using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_Arch
{
    private World               world;
    private QueryDescription    queryDescription;
    private ForEach1            forEach;
    
    [GlobalSetup]
    public void Setup()
    {
        world   = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        queryDescription = new QueryDescription().WithAll<Component1>();
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
        world.InlineQuery<ForEach1, Component1>(queryDescription, ref forEach);
    }
}