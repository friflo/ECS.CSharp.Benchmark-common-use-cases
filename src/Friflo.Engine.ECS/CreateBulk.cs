using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class CreateBulk_Friflo : CreateBulk
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
        var archetype1  = world.GetArchetype(ComponentTypes.Get<Component1>());
        var entities    = archetype1.CreateEntities(Constants.CreateBulkCount);
        for (int n = 0; n < entities.Count; n++) {
            var data = entities[n].Data;
            data.Get<Component1>().Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        var archetype3 = world.GetArchetype(ComponentTypes.Get<Component1,Component2,Component3>());
        var entities = archetype3.CreateEntities(Constants.CreateBulkCount);
        for (int n = 0; n < entities.Count; n++) {
            var data = entities[n].Data;
            data.Get<Component1>().Value = n;
            data.Get<Component2>().Value = n;
            data.Get<Component3>().Value = n;
        }
    }
}