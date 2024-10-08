﻿using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_FlecsNet : AddRemoveLinks
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    private Entity[]    relations;

    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        sources     = world.CreateEntities(Entities).AddComponents();
        targets     = world.CreateEntities(Relations).AddComponents();
        relations   = world.CreateEntities(Relations);
        foreach (var relation in relations) {
            relation.Set(new LinkRelation()); // add a component with data to every relation entity
        }
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var source in sources)
        {
            for (int n = 0; n < Relations; n++) {
                source.Add(relations[n], targets[n]);
            }
            for (int n = 0; n < Relations; n++) {
                source.Remove(relations[n], targets[n]);
            }
        }
    }
}