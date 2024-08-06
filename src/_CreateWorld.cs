
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.CreateWorld)]
public abstract class CreateWorld
{
    public abstract void Run();
}
