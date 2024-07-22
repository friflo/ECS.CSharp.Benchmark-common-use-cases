using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_FlecsNet
{
    private World   world;
    private Query   query;

    
    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        query = world.QueryBuilder().With<Component1>().Build();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n]; 
                                entity.Set(new Component1());
            if ((n &   1) != 0) entity.Set(new Component2());
            if ((n &   2) != 0) entity.Set(new Component3());
            if ((n &   4) != 0) entity.Set(new Component4());
            if ((n &   8) != 0) entity.Set(new Component5());
        }
        Check.AreEqual(Constants.FragmentationCount, query.Count());
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        query.Iter((Iter _, Span<Component1> c1Span) => {
            foreach (ref var c1 in c1Span) {
                c1.Value++;
            }
        });
    }
}