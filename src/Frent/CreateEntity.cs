using BenchmarkDotNet.Attributes;
using CommandLine.Text;

namespace Frent;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Frent : CreateEntity
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
        for (int n = 0; n < Entities; n++)
        {
            world.Create<Component1>(new(n));
        }
    }

    protected override void CreateEntity3Components()
    {
        for (int n = 0; n < Entities; n++)
        {
            world.Create<Component1, Component2, Component3>(new(n), new(n), new(n));
        }
    }
}