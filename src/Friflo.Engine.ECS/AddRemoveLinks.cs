using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.AddRemoveLinks)]
// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Friflo
{
    private Entity[]    sources;
    private Entity[]    targets;
    
    [Params(Constants.TargetCountP1, Constants.TargetCountP2)]
    public  int         RelationCount { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var world   = new EntityStore();
        sources     = world.CreateEntities(Constants.EntityCount).AddComponents();
        targets     = world.CreateEntities(RelationCount).AddComponents();
    }
    
    [Benchmark(Baseline = true)]
    public void Run()
    {
        foreach (var source in sources)
        {
            for (int n = 0; n < RelationCount; n++) {
                source.AddRelation(new LinkRelation { Value = n, Target = targets[n] });
            }
            for (int n = 0; n < RelationCount; n++) {
                source.RemoveRelation<LinkRelation>(targets[n]);
            }
        }
    }
}