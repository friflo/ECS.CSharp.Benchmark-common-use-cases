namespace Friflo.Engine.ECS.Types;

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