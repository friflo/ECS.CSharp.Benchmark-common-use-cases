using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_Morpeh : QueryFragmented
{
    private World        world;
    private StashSystem  stashSystem;

    [GlobalSetup]
    public void Setup()
    {
        world = World.Create();
        var entities = world.CreateEntities(Constants.FragmentationCount);
        stashSystem = new StashSystem { World = world };
        stashSystem.OnAwake();
        for (int n = 0; n < Constants.FragmentationCount; n++) {
            var entity = entities[n];
                                entity.AddComponent<Component1>();
            if ((n &   1) != 0) entity.AddComponent<Component2>();
            if ((n &   2) != 0) entity.AddComponent<Component3>();
            if ((n &   4) != 0) entity.AddComponent<Component4>();
            if ((n &   8) != 0) entity.AddComponent<Component5>();
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