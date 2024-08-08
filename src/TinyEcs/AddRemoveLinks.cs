using BenchmarkDotNet.Attributes;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public class AddRemoveLinks_TinyEcs : AddRemoveLinks
{
    private World           world;
    private EntityView[]    sources;
    private EntityView[]    targets;
    private EntityView[]    relations;

    [GlobalSetup]
    public void Setup()
    {
        world       = new World();
        sources     = world.CreateEntities(Entities).AddComponents();
        targets     = world.CreateEntities(Relations).AddComponents();
        relations   = world.CreateEntities(Relations);
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
    public override void Run()
    {
        foreach (var source in sources)
        {
           for (int n = 0; n < Relations; n++) {
                source.Add(relations[n], targets[n]);
            }
            for (int n = 0; n < Relations; n++) {
                source.Unset(relations[n], targets[n]);
            }
        }
    }
}