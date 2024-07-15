// ReSharper disable NotAccessedPositionalProperty.Global
namespace TinyEcs;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

public record struct Component1(int Value);

public record struct Component2(int Value);

public record struct Component3(int Value);

public record struct Component4(int Value);

public record struct Component5(int Value);

// ReSharper disable once NotAccessedPositionalProperty.Global
internal record struct LinkRelation;

internal record struct Tag1;
internal record struct Tag2;
internal record struct Tag3;
internal record struct Tag4;
internal record struct Tag5;
internal record struct Tag6;
internal record struct Tag7;
internal record struct Tag8;
internal record struct Tag9;
internal record struct Tag10;

// --- TinyEcs specific: discriminator for relations are tags
internal record struct Relation(int Value);
