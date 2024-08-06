using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(CommandBufferAddRemove))]
public abstract class CommandBufferAddRemove
{
    public abstract void Run();
}
