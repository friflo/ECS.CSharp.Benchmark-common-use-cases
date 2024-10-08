﻿using Xunit;

namespace Friflo.Engine.ECS;

// ReSharper disable once InconsistentNaming
public static class Tests_Friflo
{
    [Fact]
    public static void CheckTreeCycles()
    {
        var world   = new EntityStore();
        var entity1 = world.CreateEntity(1);
        var entity2 = world.CreateEntity(2);
        entity1.AddChild(entity2);
        var e = Assert.Throws<InvalidOperationException>(() => {
            entity2.AddChild(entity1);
        });
        Assert.Equal("operation would cause a cycle: 2 -> 1 -> 2", e!.Message);
        Assert.True(entity1 == entity2.Parent);
        Assert.True(entity1.Parent.IsNull);
    }
}