using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.ComponentEvents)]
// ReSharper disable once InconsistentNaming
public class ComponentEvents_Friflo
{
    private Entity[]    entities;
    private int         iterations;
    private int         added;
    private int         removed;
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        entities    = world.CreateEntities(Constants.EventCount);
        world.OnComponentRemoved += _ => { removed++; };
        world.OnComponentAdded   += _ => { added++;   };
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        var expect = iterations * Constants.EventCount;
        Assert.AreEqual(expect, added);
        Assert.AreEqual(expect, removed);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        iterations++;
        foreach (var entity in entities) {
            entity.Add(new Component1());
            entity.Remove<Component1>();
        }
    }
}