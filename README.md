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

| Benchmark                                 | Category                              | Description
|------------------------------------------ | ------------------------------------- | -------------------------------------------------------------------------------
| Add / Remove 1 component on 100 entities  | `AddRemoveComponentsT1`               | Check performance impact by the structural change in Archetype based ECS projects.
| Add / Remove 5 components on 100 entities | `AddRemoveComponentsT5`               | Check performance impact by the structural change in Archetype based ECS projects.
| Create 100.000 entities with 1 component  | `CreateEntityT1`                      | 
| Create 100.000 entities with 3 components | `CreateEntityT3`                      | 
| Create world                              | `CreateWorld`                         | Check memory and CPU resources required by a new World.
| Delete 100.000 entities with 5 components | `DeleteEntity`                        | 
| Get / Set 1 component on 100 entities     | `GetSetComponentsT1`                  | 
| Query 100 entities with 1 component       | `QueryT1`                             | Check performance impact by cache misses in Sparse Set based ECS projects.
| Query 100 entities with 5 components      | `QueryT5`                             | Check performance impact by cache misses in Sparse Set based ECS projects.
|                                           |                                       | 
| **Projects with relation support**        |                                       | 
| Add / Remove 1 link relation              | `AddRemoveLinks` `TargetCount`: 1     | Check memory and CPU resources required for a new relation.
| Add / Remove 100 link relations           | `AddRemoveLinks` `TargetCount`: 100   | Check memory and CPU resources required for a new relation.


```
BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
```

## Add / Remove 1 component on 100 entities

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |        982 ns |     0.18 |           - | 
| DefaultEcs        |      1,468 ns |     0.26 |           - | 
| Scellecs.Morpeh   |      1,836 ns |     0.33 |           - | 
| Flecs.NET         |      2,929 ns |     0.53 |           - | 
| Friflo.Engine.ECS |      5,565 ns |     1.00 |           - | 
| Arch              |      8,408 ns |     1.51 |     12000 B | 
| TinyEcs           |      8,880 ns |     1.60 |      6400 B | 
| fennecs           |     38,943 ns |     7.00 |     86400 B |  


## Add / Remove 5 components on 100 entities

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,150 ns |     0.67 |           - | 
| DefaultEcs        |      7,227 ns |     0.94 |           - | 
| Friflo.Engine.ECS |      7,653 ns |     1.00 |           - | 
| Scellecs.Morpeh   |      7,673 ns |     1.00 |           - | 
| Arch              |     23,324 ns |     3.05 |      8800 B | 
| Flecs.NET         |     29,655 ns |     3.87 |           - | 
| TinyEcs           |     72,474 ns |     9.47 |     64000 B | 
| fennecs           |    304,670 ns |    39.81 |    620800 B | 


## Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    559,041 ns |     1.00 |       736 B | 
| Leopotam.EcsLite  |  1,977,159 ns |     3.47 |   7316032 B | 
| Arch              |  2,747,543 ns |     5.73 |      3088 B | 
| DefaultEcs        |  3,117,007 ns |     5.56 |  11596552 B | 
| Flecs.NET         |  3,672,273 ns |     6.47 |      1152 B | 
| TinyEcs           |  5,214,321 ns |     9.21 |   8020784 B | 
| fennecs           | 26,732,532 ns |    47.45 |  58844200 B | 
| Scellecs.Morpeh   | 43,161,848 ns |    76.25 |  42293152 B | 


## Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,113,676 ns |     1.00 |       736 B | 
| Leopotam.EcsLite  |  3,558,731 ns |     3.21 |  11498680 B | 
| Arch              |  5,358,092 ns |     4.83 |      3088 B | 
| DefaultEcs        |  5,833,096 ns |     5.24 |  19984544 B | 
| Flecs.NET         | 12,814,504 ns |    11.52 |      1984 B | 
| TinyEcs           | 20,847,062 ns |    18.79 |  21824112 B | 
| Scellecs.Morpeh   | 30,036,222 ns |    27.07 |  49284080 B | 
| fennecs           | 89,222,205 ns |    80.41 | 196147968 B | 

## Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         72 ns |     0.34 |       336 B | 
| Friflo.Engine.ECS |        216 ns |     1.00 |      3576 B | 
| Leopotam.EcsLite  |      1,463 ns |     6.76 |     58944 B | 
| Arch              |      3,364 ns |    15.54 |     37040 B | 
| Scellecs.Morpeh   |      4,307 ns |    19.89 |      5056 B | 
| fennecs           |     15,134 ns |    69.91 |    169796 B | 
| TinyEcs           |     35,831 ns |   165.51 |   1087272 B | 
| Flecs.NET         |    984,064 ns | 4,545.19 |      2394 B | 

## Delete 100.000 entities with 5 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,629,512 ns |     1.00 |   3122896 B | 
| Flecs.NET         |  1,829,085 ns |     1.12 |       736 B | 
| Arch              |  2,700,191 ns |     1.66 |      3088 B | 
| DefaultEcs        |  3,728,846 ns |     2.27 |   3200736 B | 
| Leopotam.EcsLite  |  4,763,063 ns |     2.92 |   6268768 B | 
| fennecs           |  5,772,987 ns |     3.54 |   4366912 B | 
| TinyEcs           |  8,001,202 ns |     4.91 |      1144 B | 
| Scellecs.Morpeh   |  8,471,780 ns |     5.26 |   1398360 B | 

## Get / Set 1 component on 100 entities

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.43 |           - | 
| DefaultEcs        |        111 ns |     0.74 |           - | 
| Friflo.Engine.ECS |        151 ns |     1.00 |           - | 
| Arch              |        310 ns |     2.05 |           - | 
| Scellecs.Morpeh   |        326 ns |     2.16 |           - | 
| TinyEcs           |        989 ns |     6.53 |           - | 
| Flecs.NET         |      1,041 ns |     6.88 |           - | 
| fennecs           |      2,342 ns |    15.46 |           - | 

## Query 100 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         44 ns |     0.98 |           - | 
| Friflo.Engine.ECS |         45 ns |     1.00 |           - | 
| Leopotam.EcsLite  |         76 ns |     1.68 |           - | 
| TinyEcs           |         90 ns |     1.98 |           - | 
| Flecs.NET         |        112 ns |     2.46 |           - | 
| Arch              |        121 ns |     2.66 |           - | 
| fennecs           |        166 ns |     3.65 |        40 B | 
| Scellecs.Morpeh   |        314 ns |     6.90 |           - | 

## Query 100 entities with 5 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |        111 ns |     1.00 |           - | 
| TinyEcs           |        148 ns |     1.33 |           - | 
| Arch              |        197 ns |     1.77 |           - | 
| Flecs.NET         |        248 ns |     2.23 |           - | 
| DefaultEcs        |        271 ns |     2.44 |           - | 
| Leopotam.EcsLite  |        339 ns |     3.04 |           - | 
| fennecs           |        403 ns |     3.62 |        40 B | 
| Scellecs.Morpeh   |        784 ns |     7.03 |           - | 


## Add / Remove link relations

Some ECS projects have support for [Entity Relationships](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#entity-relationships).

### Add / Remove 1 link relation
| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | 1           |       5 μs |  1.00 |           - | 
| Flecs.NET         | 1           |       9 μs |  1.94 |           - | 
| TinyEcs           | 1           |      25 μs |  5.02 |     22400 B | 
| fennecs           | 1           |      93 μs | 18.11 |    180000 B | 

### Add / Remove 100 link relations

| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Flecs.NET         | 100         |     936 μs |  0.80 |         1 B | 
| Friflo.Engine.ECS | 100         |   1,171 μs |  1.00 |         1 B | 
| TinyEcs           | 100         |   8,680 μs |  7.41 |  18080012 B | 
| fennecs           | 100         |  71,750 μs | 61.26 |  93124905 B | 

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




