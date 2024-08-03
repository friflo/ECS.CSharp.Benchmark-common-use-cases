using BenchmarkDotNet.Attributes;

namespace Scellecs.Morpeh;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Morpeh
{
    private World       world;
    private StashSystem stashSystem;

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
        private Access              access;
        private Filter              filter;

        public void OnAwake()
        {
            access = new Access(World);
            filter = World.Filter.With<Component1>().With<Component2>().With<Component3>().With<Component4>().With<Component5>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in filter) {
                access.stash1.Get(entity).Value =
                    access.stash2.Get(entity).Value +
                    access.stash3.Get(entity).Value +
                    access.stash4.Get(entity).Value +
                    access.stash5.Get(entity).Value;
            }
        }

        public void Dispose()
        {
            access.Dispose();
        }
    }
}