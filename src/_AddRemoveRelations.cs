using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(AddRemoveRelations))]
public abstract class AddRemoveRelations
{
    [Params(1, 10)]
    public  int         RelationCount { get; set; }

    [Benchmark]
    public virtual void Run()
    {
        if (RelationCount == 1) {
            AddRemove1Relation();
            return;
        }
        AddRemove10Relations();
    }

    protected abstract void AddRemove1Relation();
    protected abstract void AddRemove10Relations();
}
