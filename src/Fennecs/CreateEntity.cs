﻿using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Fennecs : CreateEntity
{
    private World   world;

    [IterationSetup]
    public void Setup()
    {
        world = new World();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        world.Entity()
            .Add(new Component1())
            .Spawn(Constants.CreateEntityCount);
    }

    protected override void CreateEntity5Components()
    {
        world.Entity()
            .Add(new Component1())
            .Add(new Component2())
            .Add(new Component3())
            .Spawn(Constants.CreateEntityCount);
    }
}