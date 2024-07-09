using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponents1
{
    private Entity entity;
    
    [GlobalSetup]
    public void Setup() {
        var world = new World();
        entity = world.Spawn();
    }
    
    [Benchmark]
    public void Run() {
        entity.Add(new Component1());
        entity.Remove<Component1>();
    }
}