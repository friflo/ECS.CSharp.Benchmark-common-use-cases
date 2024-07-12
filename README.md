# ECS.CSharp.Benchmark - Common use-cases

Motivation of this benchmark project:

- Compare performance of common uses cases of multiple ECS projects.  

- Utilize a common ECS operation of a specific ECS project in most **simple & performant** way.  
  This make this benchmarks applicable to support migration from one ECS to another.

- The majority of C# ECS benchmarks focus on big data sets. Typically a multiple of 100.000 entities.  
  This sets a bias for many ECS implementations. Its also likely having many queries (systems) dealing only with 10, 100 or no entities.  
  In this case the setup cost for queries (systems) and command buffers gets relevant and can become the bottleneck.
  This benchmark has its focus on this case.

- Having an alternative to the popular [Ecs.CSharp.Benchmark](https://github.com/Doraku/Ecs.CSharp.Benchmark).  
  As the mentioned project is currently not active maintained.


## Tested projects

Ordered by GitHub Activity

| ECS                                                                                           | ECS implementation | Entity | Notes
|---------------------------------------------------------------------------------------------- | ------------------ | -------| -------------
| [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)   | Archetype          | struct |
| [fennecs](https://github.com/thygrrr/fennecs)                                                 | Archetype          | struct |
| [TinyEcs](https://github.com/andreakarasho/TinyEcs)                                           | Archetype          | struct |
| [Arch](https://github.com/genaray/Arch)                                                       | Archetype          | struct |
| [Flecs.Net](https://github.com/BeanCheeseBurrito/Flecs.NET)                                   | Archetype          | struct |
| [Morpeh](https://github.com/scellecs/morpeh)                                                  | ?                  | class  |
| [Leopotam.EcsLite](https://github.com/Leopotam/ecslite)                                       | Sparse Set         | int    | The used nuget package is not published by the project owner
| [DefaultEcs](https://github.com/Doraku/DefaultEcs)                                            | Sparse Set         | struct |


## ECS implementation

The are typically two types used by many ECS projects

### Archetype

Entities are stored in single array. Components as stored in "tables" aka Archetypes.  
An Archetype contains arrays of components for a specific set of component types.

**Pros:** Enable fast iteration of component queries.  
**Cons**: Add/remove operations require a structural change.  

### Sparse Set

A sparse Set based ECS stores each component in its own sparse set which is has the entity id as key.

**Pros:** Fast add/remove operations.  
**Cons:** Each component type requires an array with the size of all components.  

<br/>


# Benchmarks

| Benchmark                             | Description               
|-------------------------------------- | --------------------------------------------------------------
| Add / Remove 1 component              | Check performance impact by the structural change in Archetype based ECS projects.
| Add / Remove 5 components             | Check performance impact by the structural change in Archetype based ECS projects.
| Create entity                         |
| Create world                          | Check memory and CPU resources required by a new World.
| Delete entity                         |
| Get / Set component                   | 
| Query with 1 component                | Check performance impact by cache misses in Sparse Set based ECS projects.
| Query with 5 components               | Check performance impact by cache misses in Sparse Set based ECS projects.
|                                       | 
| **Projects with relation support**    | 
| Add / Remove 1 link relation          | Check memory and CPU resources required for a new relation.
| Add / Remove 100 link relations       | Check memory and CPU resources required for a new relation.


```
BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
```

## Add / Remove 1 component

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| Leopotam.EcsLite  |    10,963 ns |     0.22 |         - | 
| DefaultEcs        |    14,415 ns |     0.29 |         - | 
| Scellecs.Morpeh   |    24,150 ns |     0.49 |         - | 
| Flecs.NET         |    28,804 ns |     0.59 |         - | 
| Friflo.Engine.ECS |    48,965 ns |     1.00 |         - | 
| Arch              |    86,276 ns |     1.76 |  120000 B | 
| TinyEcs           |    87,688 ns |     1.79 |   64000 B | 
| fennecs           |   391,123 ns |     7.99 |  864000 B | 

## Add / Remove 5 components

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| Leopotam.EcsLite  |    52,533 ns |     0.75 |         - | 
| Friflo.Engine.ECS |    69,852 ns |     1.00 |         - | 
| DefaultEcs        |    73,653 ns |     1.05 |         - | 
| Scellecs.Morpeh   |    83,695 ns |     1.20 |         - | 
| Arch              |   228,779 ns |     3.28 |   88000 B | 
| Flecs.NET         |   293,809 ns |     4.21 |         - | 
| TinyEcs           |   713,651 ns |    10.22 |  640001 B | 
| fennecs           | 3,056,342 ns |    43.76 | 6208003 B | 

## Create entity

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| Leopotam.EcsLite  |         2 ns |     0.39 |      21 B | 
| Friflo.Engine.ECS |         7 ns |     1.00 |       5 B | 
| DefaultEcs        |        12 ns |     1.73 |      66 B | 
| Flecs.NET         |        20 ns |     2.82 |       1 B | 
| Arch              |        25 ns |     3.36 |      36 B | 
| fennecs           |        27 ns |     3.67 |     214 B | 
| TinyEcs           |        41 ns |     6.48 |       1 B | 
| Scellecs.Morpeh   |        80 ns |    10.73 |     376 B | 

## Create world

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| DefaultEcs        |        72 ns |     0.34 |     336 B | 
| Friflo.Engine.ECS |       215 ns |     1.00 |    3576 B | 
| Leopotam.EcsLite  |     1,462 ns |     6.79 |   58944 B | 
| Arch              |     3,378 ns |    15.68 |   37040 B | 
| Scellecs.Morpeh   |     4,294 ns |    19.93 |    5056 B | 
| fennecs           |    21,371 ns |    99.18 |  169820 B | 
| TinyEcs           |    35,929 ns |   166.74 | 1087272 B | 
| Flecs.NET         |   926,724 ns | 4,300.78 |    2381 B | 

## Delete entity

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| Leopotam.EcsLite  |         3 ns |     0.25 |       5 B | 
| DefaultEcs        |        11 ns |     0.77 |      33 B | 
| Friflo.Engine.ECS |        15 ns |     1.00 |       1 B | 
| Flecs.NET         |        17 ns |     1.20 |       1 B | 
| Arch              |        18 ns |     1.22 |      15 B | 
| fennecs           |        19 ns |     1.32 |      25 B | 
| TinyEcs           |        55 ns |     3.72 |       1 B | 
| Scellecs.Morpeh   |       111 ns |     8.07 |      46 B | 

## Get / Set entity

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| Leopotam.EcsLite  |       668 ns |     0.42 |         - | 
| DefaultEcs        |     1,099 ns |     0.69 |         - | 
| Friflo.Engine.ECS |     1,590 ns |     1.00 |         - | 
| Arch              |     3,263 ns |     2.05 |         - | 
| Scellecs.Morpeh   |     3,943 ns |     2.48 |         - | 
| TinyEcs           |     9,545 ns |     6.00 |         - | 
| Flecs.NET         |    10,342 ns |     6.50 |         - | 
| fennecs           |    24,902 ns |    15.66 |         - | 

## Query with 1 component

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| TinyEcs           |       364 ns |     0.75 |         - | 
| DefaultEcs        |       484 ns |     1.00 |         - | 
| Friflo.Engine.ECS |       487 ns |     1.00 |         - | 
| Flecs.NET         |       574 ns |     1.18 |         - | 
| Arch              |       584 ns |     1.20 |         - | 
| fennecs           |       616 ns |     1.27 |      40 B | 
| Leopotam.EcsLite  |       778 ns |     1.60 |         - | 
| Scellecs.Morpeh   |     3,973 ns |     8.16 |         - | 

## Query with 5 components

| ECS               | Mean         | Ratio    | Allocated | 
|------------------ |-------------:|---------:|----------:|
| TinyEcs           |       851 ns |     0.92 |         - | 
| Friflo.Engine.ECS |       927 ns |     1.00 |         - | 
| Arch              |     1,190 ns |     1.28 |         - | 
| fennecs           |     1,360 ns |     1.47 |      40 B | 
| Flecs.NET         |     1,998 ns |     2.15 |         - | 
| DefaultEcs        |     2,643 ns |     2.85 |         - | 
| Leopotam.EcsLite  |     3,287 ns |     3.54 |         - | 
| Scellecs.Morpeh   |     9,318 ns |    10.04 |         - |


## Add / Remove link relations

Some ECS projects have support for [Entity Relationships](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#entity-relationships).

### Add / Remove 1 link relation
| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | 1           |      51 μs |  1.00 |           - | 
| fennecs           | 1           |     938 μs | 18.39 |   1800001 B | 

### Add / Remove 100 link relations

| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | 100         |  11,890 μs |  1.00 |        12 B | 
| fennecs           | 100         | 718,838 μs | 60.46 | 931248736 B | 

<br/>


# Setup

Running all 68 benchmarks ~ 7 minutes

The benchmark project can be build and executed on **Windows**, **macOS** & **Linux**.  
All popular IDE's can be used to run and debug the project: **Rider**, **Visual Studio Code** & **Visual Studio**.

**Benchmark constraints**

- Each benchmark is **simple** and uses the fastest single threaded variant available.
- Each Benchmark shares no state or code with any other benchmarks.
- Adding or removing a benchmark implementation has no effect on all others.
- Each project has an extension class `BenchUtils` with two methods to used by its benchmarks.  
  `BenchUtils.CreateEntities(int count)`  
  `BenchUtils.AddComponents(this Entity[] entities)`  

Benchmarks changing the state of World in a way that has influence on the measurement have a specific handling.  
Currently these Benchmarks are `CreateEntity` and `DeleteEntity`.  
They are attributed with
```
[InvocationCount(1000)]  // <- Constants are replaced by numbers for this explanation
[IterationCount(2000)]
```
and using a `[IterationSetup] / [IterationCleanup]` pair instead of a `[GlobalSetup] / [GlobalCleanup]` pair.  
In this case a benchmark is executed 1000 * 2000 times to ensure the JIT has finished its optimizations in `WorkloadActual` phase.  
In each iteration the benchmarked code is invoked 1000 times.  
The same applies to `WorkloadResult` phase when BDN do the measurement for the benchmark results in the summary.


## Contribution

Contributions are welcome.


## Benchmark CLI

**CLI benchmark example commands**

```shell
cd ./src

--- windows
dotnet run -c Release --filter *                                # run all benchmarks
dotnet run -c Release --filter *AddRemoveComponentsT1_Friflo*   # run a specific benchmark
dotnet run -c Release --filter *AddRemoveComponents*            # run benchmarks of single category
dotnet run -c Release --filter *Friflo*                         # run benchmarks of single project
dotnet run -c Release --filter *Friflo* *Arch*                  # compare benchmarks of two projects

# run benchmarks supported by all projects
dotnet run -c Release --filter *AddRemoveComponents* *GetSetComponents* *CreateEntity* *CreateWorld* *DeleteEntity* *Query*
dotnet run -c Release --filter *AddRemoveLinks*                 # run benchmarks of projects supporting relations

--- macos
dotnet run -c Release --filter \*                               # run all benchmarks
dotnet run -c Release --filter \*AddRemoveComponentsT1_Friflo\* # run a specific benchmark
dotnet run -c Release --filter \*AddRemoveComponents\*          # run benchmarks of single category
dotnet run -c Release --filter \*Friflo\*                       # run benchmarks of single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*              # compare benchmarks of two projects

# run benchmarks supported by all projects
dotnet run -c Release --filter \*AddRemoveComponents\* \*GetSetComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*AddRemoveLinks\*               # run benchmarks of projects supporting relations
```




