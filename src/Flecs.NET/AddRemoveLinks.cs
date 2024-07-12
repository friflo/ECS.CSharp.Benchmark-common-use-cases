using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Flecs.NET;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_FlecsNet
{
    private World       world;
    private Entity[]    sources;
    private Entity[]    targets;
    private Entity[]    relations;
    
    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        world       = World.Create();
        sources     = world.CreateEntities(Constants.EntityCount).AddComponents();
        targets     = world.CreateEntities(TargetCount).AddComponents();
        relations   = world.CreateEntities(TargetCount);
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
            for (int n = 0; n < TargetCount; n++) {
                source.Add(relations[n], targets[n] );
            }
            for (int n = 0; n < TargetCount; n++) {
                source.Remove(relations[n], targets[n]);
            }
        }
    }
}