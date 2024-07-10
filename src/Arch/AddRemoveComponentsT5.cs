using Arch.Core;
using Arch.Core.Extensions;
using Arch.Types;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Arch;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT5
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constant.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities)
        {
            entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}