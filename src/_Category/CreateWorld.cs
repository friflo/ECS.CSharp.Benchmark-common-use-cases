using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(CreateWorld))]
public abstract class CreateWorld
{
    public abstract void Run();
}
