﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class Query5
{
    private ArchetypeQuery<Component1,Component2,Component3,Component4,Component5> query;
    
    [Params(Constant.EntityCountP1)]
    public int EntityCount { get; set; }
    
    [GlobalSetup]
    public void Setup() {
        var world = new EntityStore();
        for (int n = 0; n < EntityCount; n++) {
            var entity = world.CreateEntity();
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        query = world.Query<Component1,Component2,Component3,Component4,Component5>();
    }
    
    // [Benchmark]
    public void Run() {
        foreach (var (components1, components2, components3, components4, components5, entities) in query.Chunks) {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < entities.Length; n++) {
                span1[n].value = span2[n].value + span3[n].value + span4[n].value * span5[n].value;  
            }
            
        }
    }
}