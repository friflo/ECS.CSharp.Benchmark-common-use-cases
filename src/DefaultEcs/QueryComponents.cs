using BenchmarkDotNet.Attributes;
using DefaultEcs.System;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public partial class QueryComponents_DefaultEcs : QueryComponents
{
    private World               world;
    private ComponentSystem1     componentSystem1;
    private EntitySetSystem5    entitySetSystem5;

    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Entities).AddComponents();
        componentSystem1 = new ComponentSystem1(world);
        entitySetSystem5 = new EntitySetSystem5(world);
        // query = world.Query<Component1,Component2,Component3,Component4,Component5>();
        // Assert.AreEqual(Constants.EntityCount, query.Count);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        componentSystem1.Update(0);
    }

    protected override void Run5Components()
    {
        entitySetSystem5.Update(0);
    }
}

internal class ComponentSystem1 : AComponentSystem<int,Component1>
{
    internal ComponentSystem1(World world) : base(world) { }
    protected override void Update(int state, Span<Component1> components)
    {
        foreach (ref Component1 component in components) {
            ++component.Value;
        }
    }
}

internal partial class EntitySetSystem5 : AEntitySetSystem<int>
{
    internal EntitySetSystem5(World world) : base(world, CreateEntityContainer, null, 0) { }

    [Update]
    private static void Update(ref Component1 c1, in Component2 c2, in Component3 c3, in Component4 c4, in Component5 c5)
    {
        c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;
    }
}