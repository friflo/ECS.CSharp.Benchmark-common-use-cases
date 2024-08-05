using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class AddRemoveComponents_Myriad : AddRemoveComponents
{
    private World world;
    private Entity[] entities;
    private CommandBuffer cmd;

    [GlobalSetup]
    public void Setup()
    {
        world = new WorldBuilder().Build();

        entities = world.CreateEntities(Constants.EntityCount);

        cmd = new CommandBuffer(world);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    protected override  void Run1Component()
    {
        foreach (var entity in entities)
        {
            cmd.Set(entity, new Component1());
        }
        cmd.Playback().Dispose();

        foreach (var entity in entities)
        {
            cmd.Remove<Component1>(entity);
        }
        cmd.Playback().Dispose();
    }

    protected override  void Run5Components()
    {
        foreach (var entity in entities)
        {
            cmd.Set(entity, new Component1());
            cmd.Set(entity, new Component2());
            cmd.Set(entity, new Component3());
            cmd.Set(entity, new Component4());
            cmd.Set(entity, new Component5());
        }
        cmd.Playback().Dispose();

        foreach (var entity in entities)
        {
            cmd.Remove<Component1>(entity);
            cmd.Remove<Component2>(entity);
            cmd.Remove<Component3>(entity);
            cmd.Remove<Component4>(entity);
            cmd.Remove<Component5>(entity);
        }
        cmd.Playback().Dispose();
    }
}