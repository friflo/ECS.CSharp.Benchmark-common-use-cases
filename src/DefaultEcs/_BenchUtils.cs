namespace DefaultEcs;

public static class BenchUtils
{
    public static Entity[] CreateEntities (this World world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.CreateEntity();
        }
        return entities;
    }
    
    public static Entity[] AddComponents(this Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.Set<Component1>();
            entity.Set<Component2>();
            entity.Set<Component3>();
            entity.Set<Component4>();
            entity.Set<Component5>();
        }
        return entities;
    }
}
