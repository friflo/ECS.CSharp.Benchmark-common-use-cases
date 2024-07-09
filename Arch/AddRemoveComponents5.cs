﻿using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
public class AddRemoveComponents5
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
        entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        entity.Remove<Component1, Component2, Component3, Component4, Component5>();
    }
}