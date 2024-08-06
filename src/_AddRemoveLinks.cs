using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(AddRemoveLinks))]
public abstract class AddRemoveLinks
{
    [Params(1, 100)]
    public  int         RelationCount { get; set; }

    public abstract void Run();
}
