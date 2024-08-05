using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Leopotam : GetSetComponents
{
    private EcsWorld            world;
    private int[]               entities;
    private EcsPool<Component1> ecsPoolC1;
    private EcsPool<Component2> ecsPoolC2;
    private EcsPool<Component3> ecsPoolC3;
    private EcsPool<Component4> ecsPoolC4;
    private EcsPool<Component5> ecsPoolC5;

    [GlobalSetup]
    public void Setup() {
        world       = new EcsWorld();
        entities    = world.CreateEntities(Constants.EntityCount).AddComponents(world);
        ecsPoolC1   = world.GetPool<Component1>();
        ecsPoolC2   = world.GetPool<Component2>();
        ecsPoolC3   = world.GetPool<Component3>();
        ecsPoolC4   = world.GetPool<Component4>();
        ecsPoolC5   = world.GetPool<Component5>();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Get(entity) = new Component1();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Get(entity) = new Component1();
            ecsPoolC2.Get(entity) = new Component2();
            ecsPoolC3.Get(entity) = new Component3();
            ecsPoolC4.Get(entity) = new Component4();
            ecsPoolC5.Get(entity) = new Component5();
        }
    }
}