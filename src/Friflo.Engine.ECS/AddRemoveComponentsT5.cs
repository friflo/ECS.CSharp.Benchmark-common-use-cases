using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class AddRemoveComponentsT5
{
    private Entity[] entities;
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constant.EntityCount);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}