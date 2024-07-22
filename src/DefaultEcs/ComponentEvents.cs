using BenchmarkDotNet.Attributes;

namespace DefaultEcs;

[BenchmarkCategory(Category.ComponentEvents)]
// ReSharper disable once InconsistentNaming
public class ComponentEvents_DefaultEcs
{
    private World       world;
    private Entity[]    entities;
    private int         iterations;
    private int         added;
    private int         removed;
    
    [GlobalSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Constants.EventCount);
        world.SubscribeEntityComponentAdded  ((in Entity _, in Component1 _) => { added++;   });
        world.SubscribeEntityComponentRemoved((in Entity _, in Component1 _) => { removed++; });
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
        var expect = iterations * Constants.EventCount;
        Check.AreEqual(expect, added);
        Check.AreEqual(expect, removed);
    }
    
    [Benchmark]
    public void Run()
    {
        iterations++;
        foreach (var entity in entities) {
            entity.Set(new Component1());
            entity.Remove<Component1>();
        }
    }
}