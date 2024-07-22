﻿using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.QueryT5)]
// ReSharper disable once InconsistentNaming
public class QueryT5_Friflo
{
    private ArchetypeQuery<Component1,Component2,Component3,Component4,Component5> query;
    
    [GlobalSetup]
    public void Setup()
    {
        var world = new EntityStore();
        world.CreateEntities(Constants.EntityCount).AddComponents();
        query = world.Query<Component1,Component2,Component3,Component4,Component5>();
        Check.AreEqual(Constants.EntityCount, query.Count);
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var (components1, components2, components3, components4, components5, _) in query.Chunks)
        {
            var span1 = components1.Span;
            var span2 = components2.Span;
            var span3 = components3.Span;
            var span4 = components4.Span;
            var span5 = components5.Span;
            for (int n = 0; n < components1.Length; n++) {
                span1[n].Value = span2[n].Value + span3[n].Value + span4[n].Value + span5[n].Value;
            }
        }
    }
}