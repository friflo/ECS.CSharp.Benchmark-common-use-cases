namespace Scellecs.Morpeh;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal record struct Component1(int Value) : IComponent;

internal record struct Component2(int Value) : IComponent;

internal record struct Component3(int Value) : IComponent;

internal record struct Component4(int Value) : IComponent;

internal record struct Component5(int Value) : IComponent;

/// https://github.com/scellecs/morpeh?tab=readme-ov-file#-entity
/// "if you remove last component on entity it will be destroyed on next world.Commit()"
internal record struct AliveComponent : IComponent;

