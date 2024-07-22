using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_Arch
{
    private World               world;
    private QueryDescription    queryDescription;
    private ForEach1            forEach;
    
    [GlobalSetup]
    public void Setup()
    {
        world   = World.Create();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        queryDescription = new QueryDescription().WithAll<Component1>();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n]; 
                                entity.Add<Component1>();
            if ((n &   1) != 0) entity.Add<Component2>();
            if ((n &   2) != 0) entity.Add<Component3>();
            if ((n &   4) != 0) entity.Add<Component4>();
            if ((n &   8) != 0) entity.Add<Component5>();
        }
        Check.AreEqual(Constants.FragmentationCount, world.CountEntities(queryDescription));
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