using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Morpeh
{
    private World        world;
    private StashSystem  stashSystem;
    
    [GlobalSetup]
    public void Setup() {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents(world);
        stashSystem = new StashSystem { World = world };
        stashSystem.OnAwake();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        stashSystem.OnUpdate(0);
    }
    
    private sealed class StashSystem : ISystem
    {
        public  World               World { get; set; }
        private Stash<Component1>   stash1;
        private Stash<Component2>   stash2;
        private Stash<Component3>   stash3;
        private Stash<Component4>   stash4;
        private Stash<Component5>   stash5;
        private Filter              filter;

        public void OnAwake()
        {
            stash1 = World.GetStash<Component1>();
            stash2 = World.GetStash<Component2>();
            stash3 = World.GetStash<Component3>();
            stash4 = World.GetStash<Component4>();
            stash5 = World.GetStash<Component5>();
            filter = World.Filter.With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in filter) {
                stash1.Get(entity).Value =
                    stash2.Get(entity).Value +
                    stash3.Get(entity).Value +
                    stash4.Get(entity).Value +
                    stash5.Get(entity).Value; 
            }
        }

        public void Dispose()
        {
            stash1.Dispose();
            stash2.Dispose();
            stash3.Dispose();
            stash4.Dispose();
            stash5.Dispose();
        }
    }
}