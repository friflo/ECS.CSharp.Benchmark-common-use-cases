using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_Friflo : AddRemoveLinks
{
    private Entity[]    sources;
    private Entity[]    targets;

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
                // Assert.AreEqual(n, source.GetRelation<LinkRelation, Entity>(targets[n]).Value);  // O(1)
            }
            // Assert.AreEqual(RelationCount, source.GetRelations<LinkRelation>().Length);          // O(1)
            for (int n = 0; n < RelationCount; n++) {
                source.RemoveRelation<LinkRelation>(targets[n]);
            }
        }
    }
}