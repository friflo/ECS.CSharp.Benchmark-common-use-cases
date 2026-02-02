using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class CommandBufferAddRemove_EntitiesDb : CommandBufferAddRemove
{
    private EntityDatabase db;
    private Entity[] entities;
    private CommandBuffer commands;

    [GlobalSetup]
    public void Setup()
    {
        db = new EntityDatabase(new(16384));
        entities = db.CreateEntities(Entities);
        commands = db.CreateCommandBuffer(128);
    }

    [Benchmark()]
    public override void Run()
    {
        foreach (var entity in entities)
        {
            commands.Add(entity, new Component1(), new Component2());
        }
        commands.Commit(); // Apply changes 1

        foreach (var entity in entities)
        {
            commands.Remove<Component1, Component2>(entity);
        }
        commands.Commit(); // Apply changes 2
    }
}
