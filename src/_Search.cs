
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.SearchComponentField)]
public abstract class SearchComponentField
{
    public abstract void Run();
}

[BenchmarkCategory(Category.SearchRange)]
public abstract class SearchRange // aka range query
{
    public abstract void Run();
}
