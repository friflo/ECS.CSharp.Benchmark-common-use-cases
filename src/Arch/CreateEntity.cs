    using Arch.Core;
    using Arch.Core.Extensions.Dangerous;
    using BenchmarkDotNet.Attributes;

namespace Arch;

[InvocationCount(Constants.CreateEntityCount)]
[IterationCount(Constants.CreateEntityIterationCount)]
[ShortRunJob]
public class CreateEntity
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