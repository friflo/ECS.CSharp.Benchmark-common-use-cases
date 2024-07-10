namespace TinyEcs;

public static class BenchUtils
{
    public static EntityView[] CreateEntities (this World world, int count)
    {
        var entities = new EntityView[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.Entity(); 
        }
        return entities;
    }
    
    public static EntityView[] AddComponents(this EntityView[] entities)
    {
        EntityView e = entities[0];
        
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