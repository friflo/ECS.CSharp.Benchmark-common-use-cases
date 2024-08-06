using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.ChildEntitiesAddRemove)]
public abstract class ChildEntitiesAddRemove
{
    public abstract void Run();
}
