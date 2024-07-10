using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Friflo.Engine.ECS.Types;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class AddRemoveLinks
{
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constant.TargetCountP1, Constant.TargetCountP2)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        sources     = world.CreateEntities(Constant.EntityCount).AddComponents();
        targets     = world.CreateEntities(TargetCount).AddComponents();
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var source in sources)
        {
            for (int n = 0; n < TargetCount; n++) {
                source.AddRelation(new LinkRelation { value = n, target = targets[n] });
            }
            for (int n = 0; n < TargetCount; n++) {
                source.RemoveRelation<LinkRelation>(targets[n]);
            }
        }
    }
}