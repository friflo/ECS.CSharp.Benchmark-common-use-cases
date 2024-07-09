using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveLinks
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(1, 10, 100)]
    public int LinkCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        sources = new Entity[Constant.SourceEntitiesCount];
        for (int n = 0; n < Constant.SourceEntitiesCount; n++) {
            sources[n] = world.Spawn();
        }
        targets = new Entity[LinkCount];
        for (int n = 0; n < LinkCount; n++) {
            targets[n] = world.Spawn();
        }
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var source in sources) {
            for (int n = 0; n < LinkCount; n++) {
                source.Add(new LinkRelation { value = n }, targets[n] );
            }
            for (int n = 0; n < LinkCount; n++) {
                source.Remove<LinkRelation>(targets[n]);
            }
        }
    }
}