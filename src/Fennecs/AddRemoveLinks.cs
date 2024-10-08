﻿using BenchmarkDotNet.Attributes;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Fennecs : AddRemoveLinks
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;

    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        sources = world.CreateEntities(Entities).AddComponents();
        targets = world.CreateEntities(Relations).AddComponents();
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
                source.Add(new LinkRelation { Value = n }, targets[n] );
            }
            for (int n = 0; n < Relations; n++) {
                source.Remove<LinkRelation>(targets[n]);
            }
        }
    }
}