using Arch.Core;
using Arch.Core.Extensions;

namespace Arch;

public static class BenchUtils
{
    public static Entity[] CreateEntities (this World world, int count, Entity[] entities = null)
    {
        entities ??= new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.Create();
        }
        return entities;
    }
    
    public static Entity[] AddComponents(this Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.Add<Component1>();
            entity.Add<Component2>();
            entity.Add<Component3>();
            entity.Add<Component4>();
            entity.Add<Component5>();
        }
        return entities;
    }
}

struct ForEach1 : IForEach<Component1>
{
    public void Update(ref Component1 t0)
    {
        ++t0.Value;
    }
}

struct ForEach5 : IForEach<Component1, Component2, Component3, Component4, Component5>
{
    public void Update(ref Component1 c1, ref Component2 c2, ref Component3 c3, ref Component4 c4, ref Component5 c5)
    {
        c1.Value = c2.Value + c3.Value + c4.Value + c5.Value;
    }
}