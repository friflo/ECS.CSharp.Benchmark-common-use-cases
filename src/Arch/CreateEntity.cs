using Arch.Core;
using Arch.Core.Extensions.Dangerous;
using BenchmarkDotNet.Attributes;

namespace Arch;

[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
[BenchmarkCategory(Category.CreateEntity)]
// ReSharper disable once InconsistentNaming
public class CreateEntity_Arch
{
    private World   world;
    
    [IterationSetup]
    public void Setup()
    {
        world   = World.Create();
        world.EnsureCapacity(Constants.CreateEntityCount);
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        world.Create();
    }
}