// ReSharper disable NotAccessedPositionalProperty.Global
namespace Flecs.NET;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

internal record struct Component1(int Value);

internal record struct Component2(int Value);

internal record struct Component3(int Value);

internal record struct Component4(int Value);

internal record struct Component5(int Value);


internal record struct LinkRelation(int Value);

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

// --- flecs specific: discriminator for relations are tags
internal record struct Relation(int Value);