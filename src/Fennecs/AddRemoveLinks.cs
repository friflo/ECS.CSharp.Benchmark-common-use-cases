using BenchmarkDotNet.Attributes;

namespace fennecs;

[ShortRunJob]
public class AddRemoveLinks
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constant.TargetCountP1, Constant.TargetCountP2)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        sources = world.CreateEntities(Constant.EntityCount).AddComponents();
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
                source.Add(new LinkRelation { value = n }, targets[n] );
            }
            for (int n = 0; n < TargetCount; n++) {
                source.Remove<LinkRelation>(targets[n]);
            }
        }
    }
}