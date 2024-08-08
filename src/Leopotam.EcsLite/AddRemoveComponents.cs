using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Leopotam : AddRemoveComponents
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
        entities    = world.CreateEntities(Entities);
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

    protected override  void Run1Component()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Add(entity);
        }
        foreach (var entity in entities) {
            ecsPoolC1.Del(entity);
        }
    }

    protected override  void Run5Components()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Add(entity);
            ecsPoolC2.Add(entity);
            ecsPoolC3.Add(entity);
            ecsPoolC4.Add(entity);
            ecsPoolC5.Add(entity);
        }
        foreach (var entity in entities) {
            ecsPoolC1.Del(entity);
            ecsPoolC2.Del(entity);
            ecsPoolC3.Del(entity);
            ecsPoolC4.Del(entity);
            ecsPoolC5.Del(entity);
        }
    }
}