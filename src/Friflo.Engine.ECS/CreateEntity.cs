using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Friflo : CreateEntity
{
    private EntityStore world;

    [IterationSetup]
    public void Setup()
    {
        world = new EntityStore();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }

    [Benchmark(Baseline = true)]
    public override void Run() => base.Run();

    protected override void CreateEntity1Component()
    {
        for (int n = 0; n < Entities; n++) {
            world.CreateEntity(new Component1 { Value = n });
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++) {
            world.CreateEntity(
                new Component1 { Value = n },
                new Component2 { Value = n },
                new Component3 { Value = n });
        }
    }
}