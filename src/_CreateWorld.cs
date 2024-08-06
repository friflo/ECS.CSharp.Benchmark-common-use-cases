
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(CreateWorld))]
public abstract class CreateWorld
{
    public abstract void Run();
}
