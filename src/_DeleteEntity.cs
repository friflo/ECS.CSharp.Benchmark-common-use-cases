
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(DeleteEntity))]
public abstract class DeleteEntity
{
    public abstract void Run();
}
