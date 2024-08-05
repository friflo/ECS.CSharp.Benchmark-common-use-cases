﻿using Arch.Core;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Arch : AddRemoveComponents
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

    protected override void Run1Component()
    {
        foreach (var entity in entities) {
            world.Add<Component1>(entity);
        }
        foreach (var entity in entities) {
            world.Remove<Component1>(entity);
        }
    }

    protected override  void Run5Components()
    {
        foreach (var entity in entities) {
            world.Add(entity, new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        foreach (var entity in entities) {
            world.Remove<Component1, Component2, Component3, Component4, Component5>(entity);
        }
    }
}