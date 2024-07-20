using Flecs.NET.Core;

namespace Flecs.NET;

public static class BenchUtils
{
    public static Entity[] CreateEntities (this World world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.Entity(); 
        }
        return entities;
    }
    
    public static Entity[] AddComponents(this Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.Set(new Component1());
            entity.Set(new Component2());
            entity.Set(new Component3());
            entity.Set(new Component4());
            entity.Set(new Component5());
        }
        return entities;
    }
}