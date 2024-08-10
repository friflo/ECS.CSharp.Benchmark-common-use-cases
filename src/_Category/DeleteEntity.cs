using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(DeleteEntity))]
public abstract class DeleteEntity
{
    [Params(Constants.DeleteEntityCount)]
    public  int         Entities { get; set; }

    // all BenchUtils.AddComponents() add 5 componments
    [Params(5)]
    public  int         Components { get; set; }

    public abstract void Run();
}
