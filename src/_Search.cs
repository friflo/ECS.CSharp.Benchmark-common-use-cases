
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(SearchComponentField))]
public abstract class SearchComponentField
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}

[BenchmarkCategory(nameof(SearchRange))]
public abstract class SearchRange // aka range query
{
    public abstract void Run();
}
