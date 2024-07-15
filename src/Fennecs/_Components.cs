namespace fennecs;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal record struct Component1(int Value);

internal record struct Component2(int Value);

internal record struct Component3(int Value);

internal record struct Component4(int Value);

internal record struct Component5(int Value);

// ReSharper disable once NotAccessedPositionalProperty.Global
internal record struct LinkRelation(int Value);

internal static class RelationKey
{
    public const string Key1 = nameof(Key1);
    public const string Key2 = nameof(Key2);
    public const string Key3 = nameof(Key3);
    public const string Key4 = nameof(Key4);
    public const string Key5 = nameof(Key5);
    public const string Key6 = nameof(Key6);
    public const string Key7 = nameof(Key7);
    public const string Key8 = nameof(Key8);
    public const string Key9 = nameof(Key9);
    public const string Key10= nameof(Key10);
    
    public static readonly string[] Keys = new [] { Key1, Key2, Key3, Key4, Key5, Key6, Key7, Key8, Key9, Key10 };
}
