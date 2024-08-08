using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class QueryComponents_TinyEcs : QueryComponents
{
    private World   world;
    private Query   query1;
    private Query   query5;

    [GlobalSetup]
    public void Setup() {
        world = new World();
        world.CreateEntities(Entities).AddComponents();
        query1 = world.QueryBuilder().With<Component1>().Build();
        query5 = world.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
        Check.AreEqual(Entities, query5.Count());
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach (var (e, c1) in query1.Iter<Component1>()) {
            for (var n = 0; n < e.Length; n++) {
                c1[n].Value++;
            }
        }
    }

    protected override void Run5Components()
    {
        foreach (var (e, c1, c2, c3, c4, c5) in query5.Iter<Component1, Component2, Component3, Component4, Component5>()) {
            for (var n = 0; n < e.Length; n++) {
                c1[n].Value = c2[n].Value + c3[n].Value + c4[n].Value + c5[n].Value;
            }
        }
    }
}