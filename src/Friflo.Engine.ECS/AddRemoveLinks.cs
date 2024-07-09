using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveLinks
{
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(1, 10, 100)]
    public int LinkCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        sources = new Entity[Constant.SourceEntitiesCount];
        for (int n = 0; n < Constant.SourceEntitiesCount; n++) {
            sources[n] = world.CreateEntity();
        }
        targets = new Entity[LinkCount];
        for (int n = 0; n < LinkCount; n++) {
            targets[n] = world.CreateEntity();
        }
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var source in sources) {
            for (int n = 0; n < LinkCount; n++) {
                source.AddRelation(new LinkRelation { value = n, target = targets[n] });
            }
            for (int n = 0; n < LinkCount; n++) {
                source.RemoveRelation<LinkRelation>(targets[n]);
            }
        }
    }
}