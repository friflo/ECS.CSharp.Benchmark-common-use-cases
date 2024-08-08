using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Friflo : QueryComponents
{
    private ArchetypeQuery<Component1>                                              query1;
    private ArchetypeQuery<Component1,Component2,Component3,Component4,Component5>  query5;

    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Entities).AddComponents();
        query1 = world.Query<Component1>();
        query5 = world.Query<Component1,Component2,Component3,Component4,Component5>();
        Check.AreEqual(Entities, query5.Count);
    }

    [Benchmark(Baseline = true)]
    public override void Run() => base.Run();

    protected override void Run1Component()
    {
        foreach (var (components, _) in query1.Chunks) {
            foreach (ref var component in components.Span) {
                component.Value++;
            }
        }
    }

    protected override void Run5Components()
    {
        query5.Each(new Each5());
    }
}

internal readonly struct Each5 : IEach<Component1,Component2,Component3,Component4,Component5>
{
    public void Execute(ref Component1 c1, ref Component2 c2, ref Component3 c3, ref Component4 c4, ref Component5 c5) {
        c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;
    }
}
