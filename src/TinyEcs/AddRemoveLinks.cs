﻿using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_TinyEcs
{
    private World           world;
    private EntityView[]    sources;
    private EntityView[]    targets;
    private EntityView[]    relations;

    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public  int             RelationCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        world       = new World();
        sources     = world.CreateEntities(Constants.EntityCount).AddComponents();
        targets     = world.CreateEntities(RelationCount).AddComponents();
        relations   = world.CreateEntities(RelationCount);
        foreach (var relation in relations) {
            relation.Add<LinkRelation>(); // add a component with data to every relation entity
        }
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public void Run()
    {
        foreach (var source in sources)
        {
           for (int n = 0; n < RelationCount; n++) {
                source.Add(relations[n], targets[n]);
            }
            for (int n = 0; n < RelationCount; n++) {
                source.Unset(relations[n], targets[n]);
            }
        }
    }
}