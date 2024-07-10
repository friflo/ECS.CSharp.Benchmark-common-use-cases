﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveLinks
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [Params(Constant.TargetCountP1, Constant.TargetCountP2, Constant.TargetCountP3)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        sources = new Entity[EntityCount];
        for (int n = 0; n < EntityCount; n++) {
            sources[n] = world.Spawn();
        }
        targets = new Entity[TargetCount];
        for (int n = 0; n < TargetCount; n++) {
            targets[n] = world.Spawn();
        }
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var source in sources) {
            for (int n = 0; n < TargetCount; n++) {
                source.Add(new LinkRelation { value = n }, targets[n] );
            }
            for (int n = 0; n < TargetCount; n++) {
                source.Remove<LinkRelation>(targets[n]);
            }
        }
    }
}