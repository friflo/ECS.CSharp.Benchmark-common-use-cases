using BenchmarkDotNet.Attributes;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class CreateBulk_Frent : CreateBulk
{
    private World   world;

    [IterationSetup]
    public void Setup()
    {
        world = new World();
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        var span = world.CreateMany<Component1>(Entities).Span;
        for (int n = 0; n < span.Length; n++)
        {
            span[n].Value = n;
        }
    }

    protected override void CreateEntity3Components()
    {
        var data = world.CreateMany<Component1, Component2, Component3>(Entities);
        var span1 = data.Span1;
        var span2 = data.Span2[..span1.Length];
        var span3 = data.Span3[..span1.Length];
        for (int n = 0; n < span1.Length; n++)
        {
            span1[n].Value = n;
            span2[n].Value = n;
            span3[n].Value = n;
        }
    }
}