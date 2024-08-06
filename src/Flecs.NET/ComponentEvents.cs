using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class ComponentEvents_FlecsNet : ComponentEvents
{
    private World       world;
    private Entity[]    entities;
    private int         iterations;
    private int         added;
    private int         removed;

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EventCount);
        world.Observer<Component1>().Event(Ecs.OnAdd).Each((Entity _, ref Component1 _) => {
            added++;
        });
        world.Observer<Component1>().Event(Ecs.OnRemove).Each((Entity _, ref Component1 _) => {
            removed++;
        });
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
        var expect = iterations * Constants.EventCount;
        Check.AreEqual(expect, added);
        Check.AreEqual(expect, removed);
    }

    [Benchmark]
    public override  void Run()
    {
        iterations++;
        foreach (var entity in entities) {
            entity.Set(new Component1());
            entity.Remove<Component1>();
        }
    }
}