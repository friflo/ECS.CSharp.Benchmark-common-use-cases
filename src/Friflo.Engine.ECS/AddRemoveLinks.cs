using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveLinks
{
    private Entity      entity;
    private Entity[]    targets;
    
    [Params(1, 10, 100)]
    public int LinkCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        entity = world.CreateEntity();
        targets = new Entity[LinkCount];
        for (int n = 0; n < LinkCount; n++) {
            targets[n] = world.CreateEntity();    
        }
        
    }
    
    [Benchmark]
    public void Run() {
        for (int n = 0; n < LinkCount; n++) {
            entity.AddRelation(new LinkRelation { value = 42, target = targets[n] });
        }
        for (int n = 0; n < LinkCount; n++) {
            entity.RemoveRelation<LinkRelation>(targets[n]);
        }
    }
}