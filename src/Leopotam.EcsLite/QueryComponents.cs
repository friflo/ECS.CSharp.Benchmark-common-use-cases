using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class QueryComponents_Leopotam : QueryComponents
{
    private EcsWorld            world;
    private EcsFilter           filter1;
    private EcsFilter           filter5;
    private EcsPool<Component1> c1;
    private EcsPool<Component2> c2;
    private EcsPool<Component3> c3;
    private EcsPool<Component4> c4;
    private EcsPool<Component5> c5;

    [GlobalSetup]
    public void Setup() {
        world = new EcsWorld();
        world.CreateEntities(Constants.EntityCount).AddComponents(world);
        c1      = world.GetPool<Component1>();
        c2      = world.GetPool<Component2>();
        c3      = world.GetPool<Component3>();
        c4      = world.GetPool<Component4>();
        c5      = world.GetPool<Component5>();
        filter1 = world.Filter<Component1>().End();
        filter5 = world.Filter<Component1>().Inc<Component2>().Inc<Component3>().Inc<Component4>().Inc<Component5>().End();
        Check.AreEqual(Constants.EntityCount, filter5.GetEntitiesCount());
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }

    protected override void Run1Component()
    {
        int[] entities = filter1.GetRawEntities();
        for (int i = 0, iMax = filter1.GetEntitiesCount(); i < iMax; i++) {
            ++c1.Get(entities[i]).Value;
        }
    }

    protected override void Run5Components()
    {
        int[] entities = filter5.GetRawEntities();
        for (int i = 0, iMax = filter5.GetEntitiesCount(); i < iMax; i++)
        {
            var entity = entities[i];
            c1.Get(entity).Value =
            c2.Get(entity).Value +
            c3.Get(entity).Value +
            c4.Get(entity).Value +
            c5.Get(entity).Value;
        }
    }
}