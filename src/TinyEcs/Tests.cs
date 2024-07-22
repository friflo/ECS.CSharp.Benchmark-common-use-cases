using Xunit;

namespace TinyEcs;

// ReSharper disable once InconsistentNaming
public static class Tests_TinyEcs
{
    [Fact]
    public static void CheckTreeCycles()
    {
        using var world = new World();
        var entity1 = world.Entity();
        var entity2 = world.Entity();
        entity1.AddChild(entity2);
        entity2.AddChild(entity1); // creates cycle
    }
}