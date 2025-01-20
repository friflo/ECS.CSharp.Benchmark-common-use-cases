using BenchmarkDotNet.Attributes;
using Frent.Systems;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Frent : QueryComponents
{
    private World world;
    private Query query1;
    private Query query5;

    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Entities).AddComponents();
        query1 = world.Query<With<Component1>>();
        query5 = world.Query<With<Component1, Component2, Component3, Component4, Component5>>();
        //Check.AreEqual(Entities, world.EntityCount);
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        query1.Inline<Increment, Component1>(default);
    }

    protected override void Run5Components()
    {
        query5.Inline<Increment, Component1, Component2, Component3, Component4, Component5>(default);
    }

    internal struct Increment : IAction<Component1>, IAction<Component1, Component2, Component3, Component4, Component5>
    {
        public void Run(ref Component1 arg) => arg.Value++;
        public void Run(ref Component1 arg1, ref Component2 arg2, ref Component3 arg3, ref Component4 arg4, ref Component5 arg5) =>
            arg1.Value = arg2.Value + arg3.Value + arg4.Value + arg5.Value;
    }
}