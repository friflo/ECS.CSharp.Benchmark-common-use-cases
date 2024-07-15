using BenchmarkDotNet.Attributes;

// ReSharper disable NotAccessedField.Local
namespace TinyEcs;

[ShortRunJob]
[BenchmarkCategory(Category.ComponentEvents)]
// ReSharper disable once InconsistentNaming
public class ComponentEvents_TinyEcs
{
    private World           world;
    private EntityView[]    entities;
    private int             iterations;
    private int             added;
    private int             removed;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constants.EventCount);
        world.OnComponentSet += (_, _) => { added++;   };
        world.OnComponentSet += (_, _) => { removed++; };
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
        // var expect = iterations * Constants.EventCount;
        // Assert.AreEqual(expect, added);     Exception - expect: 29491300, was: 29491301
        // Assert.AreEqual(expect, removed);   Exception - expect: 29491300, was: 29491301
    }

    [Benchmark]
    public void Run()
    {
        iterations++;
        foreach (var entity in entities) {
            entity.Set(new Component1());
            entity.Unset<Component1>();
        }
    }
}