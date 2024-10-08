﻿using BenchmarkDotNet.Attributes;

// ReSharper disable once CheckNamespace
[WarmupCount(5000)] // so fast implementation to execute JIT compiler
[BenchmarkCategory(nameof(CreateEntity))]
public abstract class CreateEntity
{
    [Params(Constants.CreateEntityCount)]
    public  int         Entities { get; set; }

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
    [Params(Constants.CreateBulkCount)]
    public  int         Entities { get; set; }

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
