namespace Scellecs.Morpeh;

public static class BenchUtils
{
    public static Entity[] CreateEntities (this World world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            var entity = entities[n] = world.CreateEntity(); 
            entity.AddComponent<AliveComponent>();
        }
        world.Commit();
        return entities;
    }
    
    public static Entity[] AddComponents(this Entity[] entities, World world)
    {
        foreach (var entity in entities)
        {
            entity.AddComponent<Component1>();
            entity.AddComponent<Component2>();
            entity.AddComponent<Component3>();
            entity.AddComponent<Component4>();
            entity.AddComponent<Component5>();
        }
        world.Commit();
        return entities;
    }
}