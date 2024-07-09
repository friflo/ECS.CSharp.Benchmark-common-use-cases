using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class AddRemoveComponent1
{
    private World   world;
    private Entity  entity;
    
    [GlobalSetup]
    public void Setup() {
        world   = World.Create();
        entity  = world.Create();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        World.Destroy(world);
    }
    
    [Benchmark]
    [BenchmarkCategory(Categories.Arch)]
    public void Run() {
        entity.Add(new Component1());
        entity.Remove<Component1>();
    }
}