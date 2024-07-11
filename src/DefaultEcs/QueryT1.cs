using BenchmarkDotNet.Attributes;
using DefaultEcs.System;

namespace DefaultEcs;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_Default
{
    private World           world;
    private ComponentSystem componentSystem;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        componentSystem = new ComponentSystem(world);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        componentSystem.Update(0);
    }
    
    private class ComponentSystem : AComponentSystem<int,Component1>
    {
        internal ComponentSystem(World world) : base(world) { }
        protected override void Update(int state, Span<Component1> components)
        {
            foreach (ref Component1 component in components) {
                ++component.value;
            }
        }
    }
}

