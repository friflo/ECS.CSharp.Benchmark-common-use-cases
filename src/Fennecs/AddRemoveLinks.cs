using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Fennecs
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        sources = world.CreateEntities(Constants.EntityCount).AddComponents();
        targets = world.CreateEntities(TargetCount).AddComponents();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var source in sources)
        {
            for (int n = 0; n < TargetCount; n++) {
                source.Add(new LinkRelation { Value = n }, targets[n] );
            }
            for (int n = 0; n < TargetCount; n++) {
                source.Remove<LinkRelation>(targets[n]);
            }
        }
    }
}