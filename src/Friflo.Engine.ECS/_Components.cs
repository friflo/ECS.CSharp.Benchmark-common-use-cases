namespace Friflo.Engine.ECS;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal struct Component1 : IComponent
{
    public int value;
}

internal struct Component2 : IComponent
{
    public int value;
}

internal struct Component3 : IComponent
{
    public int value;
}

internal struct Component4 : IComponent
{
    public int value;
}

internal struct Component5 : IComponent
{
    public int value;
}

internal struct LinkRelation : ILinkRelation
{
    public int      value;
    public Entity   target;
    public Entity   GetRelationKey() => target;
}