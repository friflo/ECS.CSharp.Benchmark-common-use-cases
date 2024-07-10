using Arch.Core;
using Arch.Core.Extensions;
using Arch.Types;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Arch;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT1
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
    public void Run() {
        entity.Add(new Component1());
        entity.Remove<Component1>();
    }
}