﻿using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;


[InvocationCount(Constants.DeleteEntityCount)]
[IterationCount(Constants.DeleteEntityIterationCount)]
[ShortRunJob]
[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Friflo
{
    private EntityStore world;
    private Entity[]    entities;
    private int         entityIndex;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EntityStore();
        entities    = world.CreateEntities(Constants.DeleteEntityCount);
        entityIndex = 0;
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world = null;
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        entities[entityIndex++].DeleteEntity();
    }
}