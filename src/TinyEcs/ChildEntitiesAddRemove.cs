using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.ChildEntitiesAddRemove)]
// ReSharper disable once InconsistentNaming
public class ChildEntitiesAddRemove_TinyEcs
{
    private World           world;
    private EntityView[]    parents;
    private EntityView[][]  children;
    private int             entityCount;
    private int             childCount;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entityCount = Constants.EntityCount;
        childCount  = Constants.ChildCount;
        parents     = world.CreateEntities(entityCount).AddComponents();
        children    = new EntityView[entityCount][];
        for (int n = 0; n < entityCount; n++) {
            children[n] = world.CreateEntities(childCount).AddComponents();
        }
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    // according to example: https://github.com/andreakarasho/TinyEcs?tab=readme-ov-file#childof
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
                children[n][child].Unset<Defaults.ChildOf>(parents[n]);
            }
        }
    }
    
    // method only for verification
    private int CountChildren()
    {
        int count = 0;
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                var hasParent = children[n][child].Has<Defaults.ChildOf>(parents[n]);
                count += hasParent ? 1 : 0;
            }
        }
        return count;
    }
}