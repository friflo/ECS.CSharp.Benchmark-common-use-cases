using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(ChildEntitiesAddRemove))]
public abstract class ChildEntitiesAddRemove
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
