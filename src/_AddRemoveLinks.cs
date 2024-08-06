using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.AddRemoveLinks)]
public abstract class AddRemoveLinks
{
    [Params(1, 100)]
    public  int         RelationCount { get; set; }

    public abstract void Run();
}
