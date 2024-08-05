using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class QueryComponents_FlecsNet : QueryComponents
{
    private World   world;
    private Query   query1;
    private Query   query5;

    [GlobalSetup]
    public void Setup() {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query1 = world.QueryBuilder().With<Component1>().Build();
        query5 = world.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        query1.Iter((Iter _, Span<Component1> c1Span) => {
            foreach (ref var c1 in c1Span) {
                c1.Value++;
            }
        });
    }

    protected override void Run5Components()
    {
        query5.Iter((Iter _,
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