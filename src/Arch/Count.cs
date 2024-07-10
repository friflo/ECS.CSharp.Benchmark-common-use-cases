using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class Count
{
    private World   world;
    private QueryDescription queryDescription;
    
    [GlobalSetup]
    public void Setup()
    {
        world   = World.Create();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        queryDescription = new QueryDescription().WithAll<Component1>();
        Assert.AreEqual(Constant.EntityCount, world.CountEntities(queryDescription));
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        world.CountEntities(queryDescription);
    }
}