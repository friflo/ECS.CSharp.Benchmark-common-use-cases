using BenchmarkDotNet.Attributes;
using fennecs;

namespace Fennecs;

[ShortRunJob]
public class QueryT1
{
    private World               world;
    private Stream<Component1>  stream;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        stream = world.Query<Component1>().Compile().Stream<Component1>();
        Assert.AreEqual(Constant.EntityCount, stream.Count);
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
            foreach (Component1 _ in components.Span) {
            }
        });
    }
}