using BenchmarkDotNet.Attributes;
using Frent.Core;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class GetSetComponents_Frent : GetSetComponents
{
    private World       world;
    private Entity[]    entities;

    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Entities).AddComponents();
    }

    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    protected override void Run1Component()
    {
        foreach(var entity in entities)
        {
            entity.Get<Component1>().Value = new();
        }
    }

    protected override void Run5Components()
    {
        foreach (var entity in entities) {
            entity.Deconstruct(out Ref<Component1> c1, out Ref<Component2> c2, out Ref<Component3> c3, out Ref<Component4> c4, out Ref<Component5> c5);
            c1.Value = new Component1();
            c2.Value = new Component2();
            c3.Value = new Component3();
            c4.Value = new Component4();
            c5.Value = new Component5();
        }
    }
}