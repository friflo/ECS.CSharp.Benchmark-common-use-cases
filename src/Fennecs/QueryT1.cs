using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
public class QueryT1
{
    private World               world;
    private Stream<Component1>  stream;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        stream = world.Query<Component1>().Compile().Stream<Component1>();
        Assert.AreEqual(Constants.EntityCount, stream.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        stream.Raw(components => {
            foreach (ref Component1 component1 in components.Span) {
                component1.value++;
            }
        });
    }
}