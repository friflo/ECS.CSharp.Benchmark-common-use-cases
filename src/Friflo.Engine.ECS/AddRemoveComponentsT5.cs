using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT5
{
    private Entity entity;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        entity = world.CreateEntity();
    }
    
    [Benchmark(Baseline = true)]
    public void Run() {
        entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        entity.Remove<Component1, Component2, Component3, Component4, Component5>();
    }
}