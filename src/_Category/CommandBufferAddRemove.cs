using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(CommandBufferAddRemove))]
public abstract class CommandBufferAddRemove
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
