using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Morpeh : QueryComponents
{
    private World           world;
    private StashSystem1     stashSystem1;
    private StashSystem5    stashSystem5;

    [GlobalSetup]
    public void Setup() {
        world = World.Create();
        world.CreateEntities(Entities).AddComponents(world);

        stashSystem1 = new StashSystem1 { World = world };
        stashSystem1.OnAwake();

        stashSystem5 = new StashSystem5 { World = world };
        stashSystem5.OnAwake();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        stashSystem1.OnUpdate(0);
    }

    protected override void Run5Components()
    {
        stashSystem5.OnUpdate(0);
    }
}

internal sealed class StashSystem1 : ISystem
{
    public  World               World { get; set; }
    private Stash<Component1>   stash1;
    private Filter              filter;

    public void OnAwake()
    {
        stash1 = World.GetStash<Component1>();
        filter = World.Filter.With<Component1>().Build();
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (Entity entity in filter) {
            ++stash1.Get(entity).Value;
        }
    }

    public void Dispose() {
        stash1.Dispose();
    }
}

internal sealed class StashSystem5 : ISystem
{
    public  World               World { get; set; }
    private Access              access;
    private Filter              filter;

    public void OnAwake()
    {
        access = new Access(World);
        filter = World.Filter.With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (Entity entity in filter) {
            access.stash1.Get(entity).Value =
                access.stash2.Get(entity).Value +
                access.stash3.Get(entity).Value +
                access.stash4.Get(entity).Value +
                access.stash5.Get(entity).Value;
        }
    }

    public void Dispose()
    {
        access.Dispose();
    }
}