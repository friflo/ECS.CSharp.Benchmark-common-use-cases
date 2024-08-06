using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.CommandBufferAddRemove)]
public abstract class CommandBufferAddRemove
{
    public abstract void Run();
}
