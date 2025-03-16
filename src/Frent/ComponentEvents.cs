using BenchmarkDotNet.Attributes;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class ComponentEvents_Frent : ComponentEvents
{
    private Entity[]    entities;
    private int         iterations;
    private int         added;
    private int         removed;

    [GlobalSetup]
    public void Setup()
    {
        var world   = new World();
        entities    = world.CreateEntities(Constants.EventCount);
        world.ComponentRemoved += (_, _) => { removed++; };
        world.ComponentAdded   += (_, _) => { added++;   };
    }

    [GlobalCleanup]
    public void Shutdown() {
        var expect = iterations * Constants.EventCount;
        Check.AreEqual(expect, added);
        Check.AreEqual(expect, removed);
    }

    [Benchmark(Baseline = true)]
    public override  void Run()
    {
        iterations++;
        foreach (var entity in entities) {
            entity.Add(new Component1());
            entity.Remove<Component1>();
        }
    }
}