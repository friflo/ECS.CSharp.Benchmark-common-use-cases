
using BenchmarkDotNet.Attributes;

[WarmupCount(5000)] // so fast implementation to execute JIT compiler
[BenchmarkCategory(nameof(CreateEntity))]
public abstract class CreateEntity
{
    [Params(1, 3)]
    public  int         Components { get; set; }

    [Benchmark]
    public virtual void Run()
    {
        switch (Components) {
            case 1: CreateEntity1Component();    return;
            case 3: CreateEntity3Components();   return;
        }
    }

    protected abstract   void CreateEntity1Component();
    protected abstract   void CreateEntity3Components();
}

[WarmupCount(5000)] // so fast implementation to execute JIT compiler
[BenchmarkCategory(nameof(CreateBulk))]
public abstract class CreateBulk
{
    [Params(1, 3)]
    public  int         Components { get; set; }

    [Benchmark]
    public virtual void Run()
    {
        switch (Components) {
            case 1: CreateEntity1Component();    return;
            case 3: CreateEntity3Components();   return;
        }
    }

    protected abstract   void CreateEntity1Component();
    protected abstract   void CreateEntity3Components();
}
