﻿using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class CountT1
{
    private ArchetypeQuery<Component1>    query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Constant.EntityCount).AddComponents();
        query = world.Query<Component1>();
        Assert.AreEqual(Constant.EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run() {
        _ = query.Count;
    }
}