using Flecs.NET.Core;
using Xunit;

namespace Flecs.NET;

// ReSharper disable once InconsistentNaming
public static class Tests_FlecsNet
{
    [Fact]
    public static void CheckTreeCycles()
    {
        using var world = World.Create();
        var entity1     = world.Entity();
        var entity2     = world.Entity();
        entity1.Add(Ecs.ChildOf, entity2);
        // entity2.Add(Ecs.ChildOf, entity1); // process exit
    }
}