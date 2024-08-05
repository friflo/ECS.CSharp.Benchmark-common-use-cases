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
        var archetype1 = world.GetArchetype(ComponentTypes.Get<Component1>());
        archetype1.CreateEntities(Constants.CreateEntityCount);
    }

    protected override void CreateEntity5Components()
    {
        var archetype3 = world.GetArchetype(ComponentTypes.Get<Component1,Component2,Component3>());
        archetype3.CreateEntities(Constants.CreateEntityCount);
    }
}