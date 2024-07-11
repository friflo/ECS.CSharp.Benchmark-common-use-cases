using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

[ShortRunJob]
[BenchmarkCategory(Category.GetSetComponentsT1)]
// ReSharper disable once InconsistentNaming
public class GetSetComponentsT1_DefaultEcs
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Get<Component1>() = new Component1();
        }
    }
}