using Arch.Core;
using Arch.Core.Utils;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.CreateEntityT3)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT3_Arch
{
    private World   world;
    private static readonly ComponentType[] ComponentTypes3 = [typeof(Component1),typeof(Component2),typeof(Component3)];
    
    [IterationSetup]
    public void Setup()
    {
        world = World.Create();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        world.Reserve(ComponentTypes3, Constants.CreateEntityCount);
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Create(ComponentTypes3);
        }
    }
}