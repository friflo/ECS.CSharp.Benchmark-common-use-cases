using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT1
{
    private Entity entity;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        entity = world.CreateEntity();
    }
    
    [Benchmark]
    public void Run() {
        entity.Add(new Component1());
        entity.Remove<Component1>();
    }
}