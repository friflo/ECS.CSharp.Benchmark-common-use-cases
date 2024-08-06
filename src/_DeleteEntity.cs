
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.DeleteEntity)]
public abstract class DeleteEntity
{
    public abstract void Run();
}
