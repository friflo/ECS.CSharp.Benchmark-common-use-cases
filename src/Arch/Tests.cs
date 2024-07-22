using Arch.Core;
using Arch.Relationships;
using Xunit;

namespace Arch;

// ReSharper disable once InconsistentNaming
public static class Tests_Arch
{
    [Fact]
    public static void CheckTreeCycles()
    {
        using var world = World.Create();
        var entity1 = world.Create();
        var entity2 = world.Create();
        entity1.AddRelationship<ParentOf>(entity2);
        entity2.AddRelationship<ParentOf>(entity1); // creates cycle
        
        Assert.True(entity1.HasRelationship<ParentOf>(entity2));
        Assert.True(entity2.HasRelationship<ParentOf>(entity1));
    }
}