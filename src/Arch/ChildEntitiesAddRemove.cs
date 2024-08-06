using Arch.Core;
using Arch.Relationships;
using BenchmarkDotNet.Attributes;

namespace Arch;

// ReSharper disable once InconsistentNaming
public class ChildEntitiesAddRemove_Arch : ChildEntitiesAddRemove
{
    private World       world;
    private Entity[]    parents;
    private Entity[][]  children;
    private int         entityCount;
    private int         childCount;

    [GlobalSetup]
    public void Setup() {
        world       = World.Create();
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

    /// according to example: https://github.com/genaray/Arch.Extended/wiki/Relationships#code-sample
    [Benchmark]
    public override void Run()
    {
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                parents[n].AddRelationship<ParentOf>(children[n][child]);
            }
        }
        // Assert.AreEqual(entityCount * childCount, CountChildren());
        for (int n = 0; n < entityCount; n++) {
            for (int child = childCount - 1; child >= 0; child--) {
                parents[n].RemoveRelationship<ParentOf>(children[n][child]);
            }
        }
    }

    // method only for verification
    private int CountChildren()
    {
        int count = 0;
        for (int n = 0; n < entityCount; n++) {
            for (int child = 0; child < childCount; child++) {
                var hasParent = parents[n].HasRelationship<ParentOf>(children[n][child]);
                count += hasParent ? 1 : 0;
            }
        }
        return count;
    }
}