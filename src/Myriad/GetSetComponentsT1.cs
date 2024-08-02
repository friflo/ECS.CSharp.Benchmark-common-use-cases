using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.GetSetComponentsT1)]
// ReSharper disable once InconsistentNaming
public class GetSetComponentsT1_Myriad
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        entities = world.CreateEntities(Constants.EntityCount);
        entities.AddComponents(world);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities)
            entity.GetComponentRef<Component1>(world) = new Component1();
    }
}