using Arch.Core;
using Arch.Core.Utils;
using BenchmarkDotNet.Attributes;

namespace Arch;

[BenchmarkCategory(Category.CreateEntityT1)]
// ReSharper disable once InconsistentNaming
public class CreateEntityT1_Arch
{
    private World   world;
    private static readonly ComponentType[] ComponentTypes1 = [typeof(Component1)];
    
    [IterationSetup]
    public void Setup()
    {
        world   = World.Create();
        world.Reserve(ComponentTypes1, Constants.CreateEntityCount);
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        for (int n = 0; n < Constants.CreateEntityCount; n++) {
            world.Create(ComponentTypes1);
        }
    }
}