using Myriad.ECS;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Myriad;

public static class _BenchUtils
{
    public static Entity[] CreateEntities(this World world, int count)
    {
        var buffer = new CommandBuffer(world);
        for (var n = 0; n < count; n++)
            buffer.Create();

        using var resolver = buffer.Playback();
        var result = new Entity[count];
        for (var i = 0; i < resolver.Count; i++)
            result[i] = resolver[i];

        return result;
    }

    public static void AddComponents(this Entity[] entities, World world)
    {
        var buffer = new CommandBuffer(world);

        foreach (var entity in entities)
        {
            buffer.Set(entity, new Component1());
            buffer.Set(entity, new Component2());
            buffer.Set(entity, new Component3());
            buffer.Set(entity, new Component4());
            buffer.Set(entity, new Component5());
        }
    }
}