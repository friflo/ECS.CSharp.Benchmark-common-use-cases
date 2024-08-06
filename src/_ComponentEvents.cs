
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(ComponentEvents))]
public abstract class ComponentEvents
{
    public abstract void Run();
}
