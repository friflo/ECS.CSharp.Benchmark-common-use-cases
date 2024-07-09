using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class AddRemoveComponents5
{
    private Entity entity;
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        entity = world.CreateEntity();
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Friflo)]
    public void Run() {
        entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        entity.Remove<Component1, Component2, Component3, Component4, Component5>();
    }
}