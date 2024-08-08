using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Fennecs : QueryComponents
{
    private World                                                           world;
    private Stream<Component1>                                              stream1;
    private Stream<Component1,Component2,Component3,Component4,Component5>  stream5;

    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Entities).AddComponents();
        stream1 = world.Query<Component1>().Compile().Stream<Component1>();
        stream5 = world.Query<Component1>().Compile().Stream<Component1,Component2,Component3,Component4,Component5>();
        Check.AreEqual(Entities, stream5.Count);
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        stream1.Raw(components => {
            foreach (ref Component1 component1 in components.Span) {
                component1.Value++;
            }
        });
    }

    protected override void Run5Components()
    {
        stream5.Raw((components1, components2, components3, components4, components5) =>
        {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].Value = span2[n].Value + span3[n].Value + span4[n].Value + span5[n].Value;
            }
        });
    }
}