
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.CreateEntity)]
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
