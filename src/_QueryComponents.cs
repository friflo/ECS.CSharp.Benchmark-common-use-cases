
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.QueryComponents)]
public abstract class QueryComponents
{
    [Params(1, 5)]
    public  int         Components { get; set; }

    [Benchmark]
    public virtual void Run()
    {
        switch (Components) {
            case 1: Run1Component();    return;
            case 5: Run5Components();   return;
        }
    }

    protected abstract   void Run1Component();
    protected abstract   void Run5Components();
}
