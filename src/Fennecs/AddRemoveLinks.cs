using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveLinks
{
    private World   world;
    private Entity  entity;
    private Entity[] targets;
    
    [Params(1, 10, 100)]
    public int LinkCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        entity = world.Spawn();
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
    public void Run() {
        for (int n = 0; n < LinkCount; n++) {
            entity.Add(new LinkRelation { value = n }, targets[n] );
        }
        for (int n = 0; n < LinkCount; n++) {
            entity.Remove<LinkRelation>(targets[n]);
        }
    }
}