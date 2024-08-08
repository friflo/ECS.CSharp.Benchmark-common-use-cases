
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(SearchComponentField))]
public abstract class SearchComponentField
{
    [Params(Constants.SearchSetSize)]
    public  int         Entities { get; set; }

    public abstract void Run();
}

[BenchmarkCategory(nameof(SearchRange))]
public abstract class SearchRange // aka range query
{
    [Params(Constants.SearchSetSize)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
