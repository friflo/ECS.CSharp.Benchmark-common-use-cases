﻿using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Leopotam : CreateEntity
{
    private EcsWorld    world;

    [IterationSetup]
    public void Setup()
    {
        world = new EcsWorld();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }

    protected override void CreateEntity1Component()
    {
        var ecsPoolC1 = world.GetPool<Component1>();
        for (int n = 0; n < Entities; n++) {
            var entity = world.NewEntity();
            ecsPoolC1.Add(entity).Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        var ecsPoolC1 = world.GetPool<Component1>();
        var ecsPoolC2 = world.GetPool<Component2>();
        var ecsPoolC3 = world.GetPool<Component3>();
        for (int n = 0; n < Entities; n++) {
            var entity = world.NewEntity();
            ecsPoolC1.Add(entity).Value = n;
            ecsPoolC2.Add(entity).Value = n;
            ecsPoolC3.Add(entity).Value = n;
        }
    }
}