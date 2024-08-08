
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(nameof(QueryComponents))]
public abstract class QueryComponents
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

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

[BenchmarkCategory(nameof(QueryFragmented))]
public abstract class QueryFragmented
{
    [Benchmark]
    public abstract void Run();
}

