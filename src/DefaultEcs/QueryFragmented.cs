using BenchmarkDotNet.Attributes;
using DefaultEcs.System;

namespace DefaultEcs;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_Default : QueryFragmented
{
    private World           world;
    private ComponentSystem componentSystem;

    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        componentSystem = new ComponentSystem(world);
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n];
                                entity.Set<Component1>();
            if ((n &   1) != 0) entity.Set<Component2>();
            if ((n &   2) != 0) entity.Set<Component3>();
            if ((n &   4) != 0) entity.Set<Component4>();
            if ((n &   8) != 0) entity.Set<Component5>();
        }
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        componentSystem.Update(0);
    }

    private class ComponentSystem : AComponentSystem<int,Component1>
    {
        internal ComponentSystem(World world) : base(world) { }
        protected override void Update(int state, Span<Component1> components)
        {
            foreach (ref Component1 component in components) {
                ++component.Value;
            }
        }
    }
}

