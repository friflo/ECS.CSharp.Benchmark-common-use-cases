﻿using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Myriad
{
    private World       world;
    private Entity[]    entities;
    private CommandBuffer cmd;

    [IterationSetup]
    public void Setup()
    {
        world       = new WorldBuilder().Build();
        entities    = world.CreateEntities(Constants.DeleteEntityCount);
        cmd         = new CommandBuffer(world);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            cmd.Delete(entity);
        }
        cmd.Playback();
    }
}