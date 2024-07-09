using System.Numerics;
using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

struct Position
{
    Vector3 value;
}

[ShortRunJob]
public class AddRemoveComponent
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
        entity.Add(new Position());
        entity.Remove<Position>();
    }
}