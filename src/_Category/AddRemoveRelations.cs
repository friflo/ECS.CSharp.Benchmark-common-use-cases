using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(AddRemoveRelations))]
public abstract class AddRemoveRelations
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    [Params(1, 100)]
    public  int         Relations { get; set; }

    [Benchmark]
    public virtual void Run()
    {
        if (Relations == 1) {
            AddRemove1Relation();
            return;
        }
        AddRemove10Relations();
    }

    protected abstract void AddRemove1Relation();
    protected abstract void AddRemove10Relations();
}
