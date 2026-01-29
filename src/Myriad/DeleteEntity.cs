using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

// ReSharper disable once InconsistentNaming
public class DeleteEntity_Myriad : DeleteEntity
{
    private World       world;
    private Entity[]    entities;
    private CommandBuffer cmd;

    [GlobalSetup]
    public void GlobalSetup()
    {
        world = new WorldBuilder().Build();
        cmd   = new CommandBuffer(world);
    }

    [IterationSetup]
    public void Setup()
    {
        entities = world.CreateEntities(Entities);
        entities.AddComponents(world);
    }

    [GlobalCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }

    [Benchmark]
    public override void Run()
    {
        foreach (var entity in entities) {
            cmd.Delete(entity);
        }
        cmd.Playback();
    }
}