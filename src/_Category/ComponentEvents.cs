using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[BenchmarkCategory(nameof(ComponentEvents))]
public abstract class ComponentEvents
{
    [Params(Constants.EntityCount)]
    public  int         Entities { get; set; }

    public abstract void Run();
}
