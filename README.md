# ECS.CSharp.Benchmark - Common use-cases

Motivation of this benchmark project:

- Compare performance of common uses cases of multiple ECS projects.  

- Utilize a common ECS operation of a specific ECS project in most **simple & performant** way.  
  This make this benchmarks applicable to support migration from one ECS to another.

- The majority of C# ECS benchmarks focus on big data sets. Typically a multiple of 100.000 entities.  
  This sets a bias for many ECS implementations. Its also likely having many queries (systems) dealing only with 10, 100 or no entities.  
  In this case the setup cost for queries (systems) and command buffers gets relevant and can become the bottleneck.  
  All benchmarks are executed on **100 entities**. Except create & delete entities are using **100.000 entities**.

- Having an alternative to the popular [Ecs.CSharp.Benchmark](https://github.com/Doraku/Ecs.CSharp.Benchmark).  
  As the mentioned project is currently not active maintained.

See comments about this benchmark at [reddit announcement post](https://www.reddit.com/r/EntityComponentSystem/comments/1e0qo62/just_published_new_github_repo_ecs_c_benchmark/)


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

| Benchmark                                         | Category                              | Description
|-------------------------------------------------- | ------------------------------------- | -------------------------------------------------------------------------------
| Add / Remove 1 component on 100 entities          | `AddRemoveComponentsT1`               | Check performance impact by the structural change in Archetype based ECS projects.
| Add / Remove 5 components on 100 entities         | `AddRemoveComponentsT5`               | Check performance impact by the structural change in Archetype based ECS projects.
| Create 100.000 entities with 1 component          | `CreateEntityT1`                      | 
| Create 100.000 entities with 3 components         | `CreateEntityT3`                      | 
| Create world                                      | `CreateWorld`                         | Check memory and CPU resources required by a new World.
| Delete 100.000 entities with 5 components         | `DeleteEntity`                        | 
| Get / Set 1 component on 100 entities             | `GetSetComponentsT1`                  | 
| Query 100 entities with 1 component               | `QueryT1`                             | Check performance impact by cache misses in Sparse Set based ECS projects.
| Query 100 entities with 5 components              | `QueryT5`                             | Check performance impact by cache misses in Sparse Set based ECS projects.
|                                                   |                                       | 
| **Projects with relation support**                |                                       | 
| Add / Remove 1 link relation on 100 entities      | `AddRemoveLinks` `TargetCount`: 1     | Check memory and CPU resources required for a new relation.
| Add / Remove 100 link relations on 100 entities   | `AddRemoveLinks` `TargetCount`: 100   | Check memory and CPU resources required for a new relation.
|                                                   |                                       | 
| **Projects with command buffer support**          |                                       | 
| Add / Remove 2 components on 100 entities         | `CommandBufferAddRemoveT2`            |


```
BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
```

## Benchmarks supported by all projects

### Add / Remove 1 component on 100 entities

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |        985 ns |     0.18 |           - | 
| DefaultEcs        |      1,472 ns |     0.26 |           - | 
| Scellecs.Morpeh   |      1,839 ns |     0.33 |           - | 
| Flecs.NET         |      2,932 ns |     0.52 |           - | 
| Friflo.Engine.ECS |      5,604 ns |     1.00 |           - | 
| Arch              |      8,407 ns |     1.50 |     12000 B | 
| TinyEcs           |      8,860 ns |     1.58 |      6400 B | 
| fennecs           |     38,806 ns |     6.92 |     86400 B | 


### Add / Remove 5 components on 100 entities

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,184 ns |     0.67 |           - | 
| DefaultEcs        |      7,318 ns |     0.95 |           - | 
| Scellecs.Morpeh   |      7,661 ns |     0.99 |           - | 
| Friflo.Engine.ECS |      7,729 ns |     1.00 |           - | 
| Arch              |     22,600 ns |     2.92 |      8800 B | 
| Flecs.NET         |     31,107 ns |     4.02 |           - | 
| TinyEcs           |     71,567 ns |     9.26 |     64000 B | 
| fennecs           |    306,096 ns |    39.60 |    620800 B | 

### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    392,928 ns |     1.00 |   3449408 B | 
| fennecs           |    865,500 ns |     2.20 |   6815576 B | 
| Leopotam.EcsLite  |  2,022,041 ns |     5.17 |   7316032 B | 
| DefaultEcs        |  3,086,095 ns |     7.93 |  11596552 B | 
| Flecs.NET         |  3,635,893 ns |     9.28 |      1152 B | 
| TinyEcs           |  5,005,610 ns |    12.75 |   8020784 B | 
| Arch              |  5,249,985 ns |    13.66 |      3088 B | 
| Scellecs.Morpeh   | 43,054,258 ns |   109.60 |  42293152 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    441,317 ns |     1.00 |   4498032 B | 
| fennecs           |    936,082 ns |     2.12 |   7866864 B | 
| Leopotam.EcsLite  |  3,552,742 ns |     8.05 |  11498680 B | 
| Arch              |  4,457,608 ns |    12.82 |      3088 B | 
| DefaultEcs        |  5,819,816 ns |    13.43 |  19984656 B | 
| Flecs.NET         | 12,676,827 ns |    28.68 |      1984 B | 
| TinyEcs           | 20,568,728 ns |    46.63 |  21824112 B | 
| Scellecs.Morpeh   | 29,992,288 ns |    67.99 |  49284080 B | 

### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         73 ns |     0.34 |       336 B | 
| Friflo.Engine.ECS |        216 ns |     1.00 |      3576 B | 
| Leopotam.EcsLite  |      1,461 ns |     6.76 |     58944 B | 
| Arch              |      3,389 ns |    15.69 |     37040 B | 
| Scellecs.Morpeh   |      4,305 ns |    19.93 |      5056 B | 
| fennecs           |     15,140 ns |    70.08 |    169796 B | 
| TinyEcs           |     36,124 ns |   167.20 |   1087272 B | 
| Flecs.NET         |    954,424 ns | 4,417.69 |      2381 B | 

### Delete 100.000 entities with 5 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,624,681 ns |     1.00 |   3122896 B | 
| Flecs.NET         |  1,833,584 ns |     1.13 |       736 B | 
| Arch              |  2,643,530 ns |     1.63 |      3088 B | 
| DefaultEcs        |  3,644,236 ns |     2.25 |   3200736 B | 
| Leopotam.EcsLite  |  4,627,492 ns |     2.84 |   6268768 B | 
| fennecs           |  5,769,115 ns |     3.55 |   4366912 B | 
| TinyEcs           |  7,974,388 ns |     4.91 |      1144 B | 
| Scellecs.Morpeh   |  8,642,839 ns |     5.25 |   1398360 B | 

### Get / Set 1 component on 100 entities

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      65.15 ns |     0.43 |           - | 
| DefaultEcs        |     111.78 ns |     0.74 |           - | 
| Friflo.Engine.ECS |     151.42 ns |     1.00 |           - | 
| Arch              |     314.31 ns |     2.08 |           - | 
| Scellecs.Morpeh   |     327.07 ns |     2.16 |           - | 
| TinyEcs           |   1,001.32 ns |     6.61 |           - | 
| Flecs.NET         |   1,038.66 ns |     6.86 |           - | 
| fennecs           |   2,346.34 ns |    15.50 |           - | 

### Query 100 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |      45.10 ns |     0.95 |           - | 
| Friflo.Engine.ECS |      47.68 ns |     1.00 |           - | 
| Leopotam.EcsLite  |      76.66 ns |     1.61 |           - | 
| TinyEcs           |      90.83 ns |     1.91 |           - | 
| Flecs.NET         |     113.66 ns |     2.38 |           - | 
| Arch              |     117.92 ns |     2.47 |           - | 
| fennecs           |     166.36 ns |     3.49 |        40 B | 
| Scellecs.Morpeh   |     312.29 ns |     6.55 |           - | 

### Query 100 entities with 5 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |     110.23 ns |     1.00 |           - | 
| TinyEcs           |     145.40 ns |     1.32 |           - | 
| Arch              |     199.98 ns |     1.81 |           - | 
| Flecs.NET         |     250.39 ns |     2.27 |           - | 
| DefaultEcs        |     271.00 ns |     2.46 |           - | 
| Leopotam.EcsLite  |     345.75 ns |     3.14 |           - | 
| fennecs           |     404.33 ns |     3.67 |        40 B | 
| Scellecs.Morpeh   |     790.32 ns |     7.17 |           - | 


## Projects supporting: **Relations**

Some ECS projects have support for [Entity Relationships](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#entity-relationships).

### Add / Remove 1 link relation on 100 entities
| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | 1           |       5 μs |  1.00 |           - | 
| Flecs.NET         | 1           |       9 μs |  1.94 |           - | 
| TinyEcs           | 1           |      25 μs |  5.02 |     22400 B | 
| fennecs           | 1           |      93 μs | 18.11 |    180000 B | 

### Add / Remove 100 link relations on 100 entities

| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Flecs.NET         | 100         |     936 μs |  0.80 |         1 B | 
| Friflo.Engine.ECS | 100         |   1,171 μs |  1.00 |         1 B | 
| TinyEcs           | 100         |   8,680 μs |  7.41 |  18080012 B | 
| fennecs           | 100         |  71,750 μs | 61.26 |  93124905 B | 


## Projects supporting: **Command buffers**

### Add / Remove 2 components on 100 entities using a command buffer

1. Add components.    Apply changes. via Playback(), Execute() or Commit()
2. Remove components. Apply changes.

| ECS               |  Mean     | Ratio | Allocated   | 
|------------------ |----------:|------:|------------:|
| Scellecs.Morpeh   |      4 μs |  0.59 |           - | 
| Friflo.Engine.ECS |      8 μs |  1.00 |           - | 
| DefaultEcs        |     16 μs |  1.92 |           - | 
| Arch              |     46 μs |  5.63 |      4800 B | 


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

```php
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
dotnet run -c Release --filter *CommandBuffer*                  # run benchmarks of projects supporting command buffers

--- macos
dotnet run -c Release --filter \*                               # run all benchmarks
dotnet run -c Release --filter \*AddRemoveComponentsT1_Friflo\* # run a specific benchmark
dotnet run -c Release --filter \*AddRemoveComponents\*          # run benchmarks of single category
dotnet run -c Release --filter \*Friflo\*                       # run benchmarks of single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*              # compare benchmarks of two projects

# run benchmarks supported by all projects
dotnet run -c Release --filter \*AddRemoveComponents\* \*GetSetComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*AddRemoveLinks\*               # run benchmarks of projects supporting relations
dotnet run -c Release --filter \*CommandBuffer\*                # run benchmarks of projects supporting command buffers
```




