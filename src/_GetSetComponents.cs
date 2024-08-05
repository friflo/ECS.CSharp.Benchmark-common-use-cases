﻿
using BenchmarkDotNet.Attributes;

[BenchmarkCategory(Category.GetSetComponents)]
public abstract class GetSetComponents
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