using BenchmarkDotNet.Attributes;
using Frent.Systems;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class QueryFragmented_Frent : QueryFragmented
{
    private World               world;
    private Query               query;

    [GlobalSetup]
    public void Setup()
    {
        world = new World();
        var entities = world.CreateEntities(Entities);
        query = world.Query<With<Component1>>();

        for (int n = 0; n < Entities; n++) {
            var entity = entities[n];
                                entity.Add(new Component1());
            if ((n &   1) != 0) entity.Add(new Component2());
            if ((n &   2) != 0) entity.Add(new Component3());
            if ((n &   4) != 0) entity.Add(new Component4());
            if ((n &   8) != 0) entity.Add(new Component5());
        }
        //Check.AreEqual(Entities, world.EntityCount);
    }


    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        query.Inline<Increment, Component1>(default);
    }

    internal struct Increment : IAction<Component1>
    {
        public void Run(ref Component1 arg) => arg.Value++;
    }
}