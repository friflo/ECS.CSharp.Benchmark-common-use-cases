using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_FlecsNet
{
    private World   world;
    private Query   query;

    
    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.QueryBuilder().With<Component1>().Build();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        query.Each<Component1>((ref Component1 c1) => {
            c1.Value++;
        });
    }
}