using Xunit;

namespace fennecs;

// ReSharper disable once InconsistentNaming
public static class Tests_Fennecs
{
    [Fact]
    public static void CheckTreeCycles()
    {
        using var world = new World();
        var entity1 = world.Spawn();
        var entity2 = world.Spawn();
        entity1.Add<ChildOf>(entity2);
        entity2.Add<ChildOf>(entity1); // creates cycle
    }
}