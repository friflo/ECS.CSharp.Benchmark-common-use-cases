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