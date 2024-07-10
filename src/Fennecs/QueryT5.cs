using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
public class QueryT5
{
    private World                                                           world;
    private Stream<Component1,Component2,Component3,Component4,Component5>  stream;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        stream = world.Query<Component1>().Compile().Stream<Component1,Component2,Component3,Component4,Component5>();
        Assert.AreEqual(Constants.EntityCount, stream.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        stream.Raw((components1, components2, components3, components4, components5) =>
        {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].value = span2[n].value + span3[n].value + span4[n].value + span5[n].value;
            }
        });
    }
}