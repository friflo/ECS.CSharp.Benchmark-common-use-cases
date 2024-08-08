using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(CommandBufferAddRemove))]
public abstract class CommandBufferAddRemove
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
