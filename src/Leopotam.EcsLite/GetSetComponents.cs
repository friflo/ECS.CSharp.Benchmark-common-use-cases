using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.GetSetComponents)]
// ReSharper disable once InconsistentNaming
public class GetSetComponents_Leopotam
{
    private EcsWorld            world;
    private int[]               entities;
    private EcsPool<Component1> ecsPoolC1;
    private EcsPool<Component2> ecsPoolC2;
    private EcsPool<Component3> ecsPoolC3;
    private EcsPool<Component4> ecsPoolC4;
    private EcsPool<Component5> ecsPoolC5;

    [Params(Constants.CompCount1, Constants.CompCount5)]
    public  int         Components { get; set; }

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

    [Benchmark]
    public void Run()
    {
        switch (Components) {
            case 1: Run1Component();    return;
            case 5: Run5Components();   return;
        }
    }

    private void Run1Component()
    {
        foreach (var entity in entities) {
            ecsPoolC1.Get(entity) = new Component1();
        }
    }

    private void Run5Components()
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