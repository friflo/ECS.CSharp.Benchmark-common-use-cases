
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.ComponentEvents)]
public abstract class ComponentEvents
{
    public abstract void Run();
}
