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
        var entities = world.CreateEntities(Constants.CreateEntityCount);
        for (int n = 0; n < entities.Length; n++) {
            buffer.Set(entities[n], new Component1 { Value = n });
        }
        buffer.Playback().Dispose();
    }

    protected override void CreateEntity3Components()
    {
        var entities = world.CreateEntities(Constants.CreateEntityCount);
        for (int n = 0; n < entities.Length; n++) {
            var entity = entities[n];
            buffer.Set(entity, new Component1 { Value = n });
            buffer.Set(entity, new Component2 { Value = n });
            buffer.Set(entity, new Component3 { Value = n });
        }
        buffer.Playback().Dispose();
    }
}