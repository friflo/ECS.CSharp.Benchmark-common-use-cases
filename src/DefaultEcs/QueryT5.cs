using BenchmarkDotNet.Attributes;
using DefaultEcs.System;

namespace DefaultEcs;

[ShortRunJob]
[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public partial class QueryT5_DefaultEcs
{
    private World           world;
    private EntitySetSystem entitySetSystem;
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        entitySetSystem = new EntitySetSystem(world);
        // query = world.Query<Component1,Component2,Component3,Component4,Component5>();
        // Assert.AreEqual(Constants.EntityCount, query.Count);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        entitySetSystem.Update(0);
    }
    
    private partial class EntitySetSystem : AEntitySetSystem<int>
    {
        internal EntitySetSystem(World world) : base(world, CreateEntityContainer, null, 0) { }
        
        [Update]
        private static void Update(ref Component1 c1, in Component2 c2, in Component3 c3, in Component4 c4, in Component5 c5)
        {
            c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;  
        }
    }
}