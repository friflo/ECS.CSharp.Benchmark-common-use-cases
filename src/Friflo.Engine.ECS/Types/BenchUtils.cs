namespace Friflo.Engine.ECS.Types;

public static class BenchUtils
{
    
    public static Entity[] CreateEntities (EntityStore world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.CreateEntity();
        }
        return entities;
    }
    
    public static Entity[] AddComponents(Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        return entities;
    }
}