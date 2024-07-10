namespace Leopotam.EcsLite;

public static class BenchUtils
{
    public static int[] CreateEntities (this EcsWorld world, int count)
    {
        var entities = new int[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.NewEntity(); 
        }
        return entities;
    }
    
    public static int[] AddComponents(this int[] entities, EcsWorld world)
    {
        EcsPool<Component1> c1 = world.GetPool<Component1>();
        EcsPool<Component2> c2 = world.GetPool<Component2>();
        EcsPool<Component3> c3 = world.GetPool<Component3>();
        EcsPool<Component4> c4 = world.GetPool<Component4>();
        EcsPool<Component5> c5 = world.GetPool<Component5>();
        
        foreach (var entity in entities)
        {
            c1.Add(entity);
            c2.Add(entity);
            c3.Add(entity);
            c4.Add(entity);
            c5.Add(entity);
        }
        return entities;
    }
}