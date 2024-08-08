using BenchmarkDotNet.Attributes;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class CreateEntity_Myriad : CreateEntity
{
    private World           world;
    private CommandBuffer   buffer;

    [IterationSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();
        buffer = new CommandBuffer(world);
    }

    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override void CreateEntity1Component()
    {
        for (var n = 0; n < Entities; n++)
            buffer.Create().Set(new Component1(n));

        buffer.Playback().Dispose();
    }

    protected override void CreateEntity3Components()
    {
        for (var n = 0; n < Entities; n++)
        {
            buffer.Create()
                  .Set(new Component1(n))
                  .Set(new Component2(n))
                  .Set(new Component3(n));
        }

        buffer.Playback().Dispose();
    }
}