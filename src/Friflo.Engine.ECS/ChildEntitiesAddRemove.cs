using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[BenchmarkCategory(Category.ChildEntitiesAddRemove)]
// ReSharper disable once InconsistentNaming
public class ChildEntitiesAddRemove_Friflo
{
    private Entity[]    parents;
    private Entity[][]  children;
    private int         entityCount;
    private int         childCount;
    
    [GlobalSetup]
    public void Setup() {
        var world   = new EntityStore();
        entityCount = Constants.EntityCount;
        childCount  = Constants.ChildCount;
        parents     = world.CreateEntities(entityCount).AddComponents();
        children    = new Entity[entityCount][];
        for (int n = 0; n < entityCount; n++) {
            children[n] = world.CreateEntities(childCount).AddComponents();
        }
    }
    
    // according to example: https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-General#child-entities
    [Benchmark]
    public void Run()
    {
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                parents[n].AddChild(children[n][child]);    
            }
        }
        // Assert.AreEqual(entityCount * childCount, CountChildren());
        for (int n = 0; n < entityCount; n++) {
            for (int child = childCount - 1; child >= 0; child--) {
                parents[n].RemoveChild(children[n][child]);
            }
        }
    }
    
    // method only for verification
    private int CountChildren()
    {
        int count = 0;
        foreach (var parent in parents) {
            count += parent.ChildEntities.Count;
        }
        return count;
    }
}