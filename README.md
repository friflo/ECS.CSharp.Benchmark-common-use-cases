# ECS.CSharp.Benchmark - Common use-cases

Motivation of this benchmark project:

- Compare performance of common uses cases of multiple ECS projects.  

- Utilize a common ECS operation of a specific ECS project in most **simple & performant** way.

- *"I want to migrate from one ECS to another"?*  
  Navigate to a specific benchmark in both projects an use their implementations as migration guide.  
  Benchmark implementations are intended to be as simple as possible.

- The majority of C# ECS benchmarks focus on big data sets. Typically a multiple of 100.000 entities.  
  This sets a bias for many ECS implementations. Its also likely having many queries (systems) dealing only with 10, 100 or no entities.  
  In this case the setup cost for queries (systems) and command buffers gets relevant and can become the bottleneck.  
  All benchmarks are executed on **100 entities**. Except create & delete entities are using **100.000 entities**.

- Having an alternative to the popular [Ecs.CSharp.Benchmark](https://github.com/Doraku/Ecs.CSharp.Benchmark).  
  As the mentioned project is currently not active maintained.

See comments about this benchmark at [reddit announcement post](https://www.reddit.com/r/EntityComponentSystem/comments/1e0qo62/just_published_new_github_repo_ecs_c_benchmark/)


# Contents

* [Tested projects](#tested-projects)
* [ECS implementation](#ecs-implementation)
* [Benchmarks](#benchmarks)
  - [Benchmarks supported by all projects](#benchmarks-supported-by-all-projects)
  - [Projects supporting: **Relations**](#projects-supporting-relations)
  - [Projects supporting: **Command buffers**](#projects-supporting-command-buffers)
* [Setup](#setup)
* [Contribution](#contribution)
* [Benchmark CLI](#benchmark-cli)

<br/>

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
| Leopotam.EcsLite  |        994 ns |     0.17 |          - | 
| DefaultEcs        |      1,520 ns |     0.26 |          - | 
| Scellecs.Morpeh   |      1,846 ns |     0.31 |          - | 
| Flecs.NET         |      2,960 ns |     0.50 |          - | 
| Friflo.Engine.ECS |      5,907 ns |     1.00 |          - | 
| Arch              |      8,402 ns |     1.42 |    12000 B | 
| TinyEcs           |      8,850 ns |     1.50 |     6400 B | 
| fennecs           |     38,003 ns |     6.43 |    86400 B | 


### Add / Remove 5 components on 100 entities

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,122 ns |     0.63 |          - | 
| DefaultEcs        |      7,237 ns |     0.89 |          - | 
| Scellecs.Morpeh   |      7,632 ns |     0.94 |          - | 
| Friflo.Engine.ECS |      8,108 ns |     1.00 |          - | 
| Arch              |     22,514 ns |     2.78 |     8800 B | 
| Flecs.NET         |     31,703 ns |     3.92 |          - | 
| TinyEcs           |     71,801 ns |     8.88 |    64000 B | 
| fennecs           |    303,704 ns |    37.54 |   620800 B | 

### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    400,073 ns |     1.00 |  3449408 B | 
| fennecs           |  1,055,624 ns |     2.54 |  6815576 B | 
| Arch              |  1,633,623 ns |     4.08 |     3088 B | 
| Leopotam.EcsLite  |  1,822,169 ns |     4.41 |  7315384 B | 
| Flecs.NET         |  3,738,708 ns |     9.18 |     1152 B | 
| TinyEcs           |  5,028,663 ns |    12.17 |  8020784 B | 
| DefaultEcs        |  9,713,514 ns |    23.46 | 11591808 B | 
| Scellecs.Morpeh   | 46,627,720 ns |   112.59 | 42293152 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    433,928 ns |     1.00 |  4498032 B | 
| fennecs           |    980,368 ns |     2.24 |  7866864 B | 
| Arch              |  1,799,461 ns |     4.14 |     3088 B | 
| Leopotam.EcsLite  |  2,903,398 ns |     6.93 | 11498800 B | 
| DefaultEcs        | 10,155,157 ns |    23.17 | 19984720 B | 
| Flecs.NET         | 12,535,255 ns |    28.61 |     1984 B | 
| TinyEcs           | 20,476,307 ns |    46.64 | 21824112 B | 
| Scellecs.Morpeh   | 42,418,928 ns |    96.81 | 49284080 B |  

### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         71 ns |     0.30 |      336 B | 
| Friflo.Engine.ECS |        239 ns |     1.00 |     3576 B | 
| Leopotam.EcsLite  |      1,456 ns |     6.11 |    58944 B | 
| Arch              |      3,377 ns |    14.16 |    37040 B | 
| Scellecs.Morpeh   |      4,295 ns |    18.01 |     5056 B | 
| fennecs           |     21,960 ns |    92.21 |   169820 B | 
| TinyEcs           |     35,735 ns |   149.77 |  1087272 B | 
| Flecs.NET         |    934,491 ns | 3,913.81 |     2381 B | 

### Delete 100.000 entities with 5 components

*Note*  
The allocations comes from the fact that the buffers used to store components are replaced by smaller buffers over time.  
Without this behavior the component buffers allocated by the ECS would never shrink.  
In case of Flecs.NET components are store in native heap which is not monitored by BenchmarkDotNet.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,597,744 ns |     1.00 |  3122896 B | 
| Flecs.NET         |  1,822,307 ns |     1.14 |      736 B | 
| Arch              |  2,723,553 ns |     1.70 |  2096360 B | 
| DefaultEcs        |  3,635,286 ns |     2.28 |  3200736 B | 
| Leopotam.EcsLite  |  4,824,839 ns |     3.03 |  6268768 B | 
| fennecs           |  5,734,411 ns |     3.59 |  4366912 B | 
| Scellecs.Morpeh   |  8,631,451 ns |     5.40 |  1398360 B | 
| TinyEcs           |  8,660,894 ns |     5.42 |     1144 B | 

### Get / Set 1 component on 100 entities

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.41 |          - | 
| DefaultEcs        |        106 ns |     0.67 |          - | 
| Friflo.Engine.ECS |        158 ns |     1.00 |          - | 
| Arch              |        285 ns |     1.80 |          - | 
| Scellecs.Morpeh   |        329 ns |     2.07 |          - | 
| TinyEcs           |        990 ns |     6.24 |          - | 
| Flecs.NET         |      1,043 ns |     6.58 |          - | 
| fennecs           |      2,550 ns |    16.08 |          - | 

### Query 100 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         45 ns |     0.93 |          - | 
| Friflo.Engine.ECS |         48 ns |     1.00 |          - | 
| Leopotam.EcsLite  |         76 ns |     1.57 |          - | 
| TinyEcs           |         90 ns |     1.84 |          - | 
| Flecs.NET         |        111 ns |     2.28 |          - | 
| Arch              |        119 ns |     2.45 |          - | 
| fennecs           |        173 ns |     3.55 |       40 B | 
| Scellecs.Morpeh   |        312 ns |     6.40 |          - | 

### Query 100 entities with 5 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |        111 ns |     1.00 |          - | 
| TinyEcs           |        145 ns |     1.31 |          - | 
| Arch              |        195 ns |     1.76 |          - | 
| Flecs.NET         |        248 ns |     2.23 |          - | 
| DefaultEcs        |        268 ns |     2.41 |          - | 
| Leopotam.EcsLite  |        347 ns |     3.12 |          - | 
| fennecs           |        417 ns |     3.75 |       40 B | 
| Scellecs.Morpeh   |        785 ns |     7.04 |          - | 

<br/>

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

<br/>

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




