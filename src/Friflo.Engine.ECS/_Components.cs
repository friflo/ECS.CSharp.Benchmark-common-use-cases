namespace Friflo.Engine.ECS;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal record struct Component1(int Value) : IComponent;

internal record struct Component2(int Value) : IComponent;

internal record struct Component3(int Value) : IComponent;

internal record struct Component4(int Value) : IComponent;

internal record struct Component5(int Value) : IComponent;

// ReSharper disable once NotAccessedPositionalProperty.Global
internal record struct LinkRelation(int Value, Entity Target) : ILinkRelation
{
    public Entity   GetRelationKey() => Target;
}

internal record struct SearchableComponent(int Value) : IIndexedComponent<int>
{
    public  int  GetIndexedValue() => Value;  // indexed field
}