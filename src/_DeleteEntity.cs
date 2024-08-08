
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(DeleteEntity))]
public abstract class DeleteEntity
{
    [Params(Constants.DeleteEntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
