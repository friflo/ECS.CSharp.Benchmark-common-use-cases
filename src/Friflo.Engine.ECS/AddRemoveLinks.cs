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
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [Params(Constant.TargetCountP1, Constant.TargetCountP2, Constant.TargetCountP3)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        sources = new Entity[EntityCount];
        for (int n = 0; n < EntityCount; n++) {
            sources[n] = world.CreateEntity();
        }
        targets = new Entity[TargetCount];
        for (int n = 0; n < TargetCount; n++) {
            targets[n] = world.CreateEntity();
        }
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var source in sources) {
            for (int n = 0; n < TargetCount; n++) {
                source.AddRelation(new LinkRelation { value = n, target = targets[n] });
            }
            for (int n = 0; n < TargetCount; n++) {
                source.RemoveRelation<LinkRelation>(targets[n]);
            }
        }
    }
}