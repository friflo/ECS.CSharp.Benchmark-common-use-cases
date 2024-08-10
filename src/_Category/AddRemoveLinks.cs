using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(AddRemoveLinks))]
public abstract class AddRemoveLinks
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    [Params(1, 100)]
    public  int         Relations { get; set; }

    public abstract void Run();
}
