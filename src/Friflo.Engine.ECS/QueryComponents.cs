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
        foreach (var (components1, components2, components3, components4, components5, _) in query5.Chunks)
        {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].Value = span2[n].Value + span3[n].Value + span4[n].Value + span5[n].Value;
            }
        }
    }
}