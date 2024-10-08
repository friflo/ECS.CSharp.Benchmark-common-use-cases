﻿using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Myriad : DeleteEntity
{
    private World       world;
    private Entity[]    entities;
    private CommandBuffer cmd;

    [IterationSetup]
    public void Setup()
    {
        world       = new WorldBuilder().Build();
        entities    = world.CreateEntities(Entities);
        entities.AddComponents(world);
        cmd         = new CommandBuffer(world);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            cmd.Delete(entity);
        }
        cmd.Playback();
    }
}