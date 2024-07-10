using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT1
{
    private World   world;
    private Entity  entity;
    
    [GlobalSetup]
    public void Setup() {
        world = new World();
        entity = world.Spawn();
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run() {
        entity.Add(new Component1());
        entity.Remove<Component1>();
    }
}