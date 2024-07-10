using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Friflo
{
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public int TargetCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        sources     = world.CreateEntities(Constants.EntityCount).AddComponents();
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