using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_FlecsNet
{
    private World   world;
    private Query   query;
    
    [GlobalSetup]
    public void Setup() {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        query.Iter((Iter _,
            Span<Component1> c1Span,
            Span<Component2> c2Span,
            Span<Component3> c3Span,
            Span<Component4> c4Span,
            Span<Component5> c5Span) =>
        {
            int len = c1Span.Length;
            for (int n = 0; n < len; n++) {
                c1Span[n].Value = c2Span[n].Value + c3Span[n].Value + c4Span[n].Value + c5Span[n].Value;
            }
        });
    }
}