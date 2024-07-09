using BenchmarkDotNet.Attributes;


namespace Friflo.Engine.ECS;

[ShortRunJob]
public class AddRemoveComponent
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
        entity.AddComponent(new Position());
        entity.Remove<Position>();
    }
}