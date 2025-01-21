namespace Frent;

public static class BenchUtils
{
    public static Entity[] CreateEntities (this World world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.Create(); 
        }
        return entities;
    }
    
    public static Entity[] AddComponents(this Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.Add<Component1>(default);
            entity.Add<Component2>(default);
            entity.Add<Component3>(default);
            entity.Add<Component4>(default);
            entity.Add<Component5>(default);
        }
        return entities;
    }
}