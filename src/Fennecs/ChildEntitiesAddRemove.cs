using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.ChildEntitiesAddRemove)]
// ReSharper disable once InconsistentNaming
public class ChildEntitiesAddRemove_Fennecs
{
    private World       world;
    private Entity[]    parents;
    private Entity[][]  children;
    private int         entityCount;
    private int         childCount;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entityCount = Constants.EntityCount;
        childCount  = Constants.ChildCount;
        parents     = world.CreateEntities(entityCount).AddComponents();
        children    = new Entity[entityCount][];
        for (int n = 0; n < entityCount; n++) {
            children[n] = world.CreateEntities(childCount).AddComponents();
        }
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    // found no concrete example. Chose ChildOf approach. An alternative is ParentOf apprach.
    // see: https://fennecs.tech/docs/Components/Relation.html
    [Benchmark]
    public void Run()
    {
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                children[n][child].Add<ChildOf>(parents[n]);
            }
        }
        // Assert.AreEqual(entityCount * childCount, CountChildren());
        for (int n = 0; n < entityCount; n++) {
            for (int child = childCount - 1; child >= 0; child--) {
                children[n][child].Remove<ChildOf>(parents[n]);
            }
        }
    }
    
    // method only for verification
    private int CountChildren()
    {
        int count = 0;
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                var hasParent = children[n][child].Has<ChildOf>(parents[n]);
                count += hasParent ? 1 : 0;
            }
        }
        return count;
    }
}