using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT1)]
// ReSharper disable once InconsistentNaming
public class QueryT1_Morpeh
{
    private World        world;
    private StashSystem  stashSystem;
    
    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        world.CreateEntities(Constants.EntityCount).AddComponents(world);
        stashSystem = new StashSystem { World = world };
        stashSystem.OnAwake();
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        stashSystem.Dispose();
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
}