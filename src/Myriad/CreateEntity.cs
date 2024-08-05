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
        foreach (var entity in entities) {
            buffer.Set(entity, new Component1());
        }
        buffer.Playback().Dispose();
    }

    protected override void CreateEntity5Components()
    {
        var entities = world.CreateEntities(Constants.CreateEntityCount);
        foreach (var entity in entities) {
            buffer.Set(entity, new Component1());
            buffer.Set(entity, new Component2());
            buffer.Set(entity, new Component3());
            buffer.Set(entity, new Component4());
            buffer.Set(entity, new Component5());
        }
        buffer.Playback().Dispose();
    }
}