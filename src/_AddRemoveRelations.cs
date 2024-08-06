using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.AddRemoveRelations)]
public abstract class AddRemoveRelations
{
    [Params(1, 10)]
    public  int         RelationCount { get; set; }
}
