// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable NotAccessedPositionalProperty.Global
namespace Friflo.Engine.ECS;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal record struct Component1(int Value) : IComponent;

internal record struct Component2(int Value) : IComponent;

internal record struct Component3(int Value) : IComponent;

internal record struct Component4(int Value) : IComponent;

internal record struct Component5(int Value) : IComponent;


internal record struct LinkRelation(int Value, Entity Target) : ILinkRelation
{
    public Entity   GetRelationKey() => Target;
}

enum RelationKey : byte
{
    Key1,
    Key2,
    Key3,
    Key4,
    Key5,
    Key6,
    Key7,
    Key8,
    Key9,
    Key10,
}

// --- Friflo specific: discriminator for relations can be any type
// Used an enum to establish similarity to flecs like relations
internal record struct Relation(RelationKey Key, int Value) : IRelationComponent<RelationKey>
{
    public RelationKey   GetRelationKey() => Key;
}

internal record struct SearchableComponent(int Value) : IIndexedComponent<int>
{
    public  int  GetIndexedValue() => Value;  // indexed field
}