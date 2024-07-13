using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
[BenchmarkCategory(Category.GetSetComponentsT1)]
// ReSharper disable once InconsistentNaming
public class GetSetComponentsT1_Arch
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            world.Get<Component1>(entity) = new Component1();
        }
    }
}