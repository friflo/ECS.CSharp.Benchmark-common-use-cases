﻿using Arch.Core;
using Arch.Core.Extensions;
using BenchmarkDotNet.Attributes;

namespace Arch;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveComponentsT5)]
// ReSharper disable once InconsistentNaming
public class AddRemoveComponentsT5_Arch
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        entities    = world.CreateEntities(Constants.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown()
    {
        World.Destroy(world);
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities) {
            entity.Remove<Component1, Component2, Component3, Component4, Component5>();
        }
    }
}