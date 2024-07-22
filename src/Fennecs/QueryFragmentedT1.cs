using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.QueryFragmentedT1)]
// ReSharper disable once InconsistentNaming
public class QueryFragmentedT1_Fennecs
{
    private World               world;
    private Stream<Component1>  stream;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        stream = world.Query<Component1>().Compile().Stream<Component1>();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n]; 
                                entity.Add(new Component1());
            if ((n &   1) != 0) entity.Add(new Component2());
            if ((n &   2) != 0) entity.Add(new Component3());
            if ((n &   4) != 0) entity.Add(new Component4());
            if ((n &   8) != 0) entity.Add(new Component5());
        }
        Check.AreEqual(Constants.FragmentationCount, stream.Count);
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
                component1.Value++;
            }
        });
    }
}