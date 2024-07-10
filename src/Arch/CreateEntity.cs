    using Arch.Core;
    using Arch.Core.Extensions.Dangerous;
    using BenchmarkDotNet.Attributes;

namespace Arch;

[InvocationCount(Constant.CreateEntityCount)]
[IterationCount(Constant.CreateEntityIterationCount)]
[ShortRunJob]
public class CreateEntity
{
    private World   world;
    
    [IterationSetup]
    public void Setup()
    {
        world   = World.Create();
        world.EnsureCapacity(Constant.CreateEntityCount);
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