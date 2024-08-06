using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(ChildEntitiesAddRemove))]
public abstract class ChildEntitiesAddRemove
{
    public abstract void Run();
}
