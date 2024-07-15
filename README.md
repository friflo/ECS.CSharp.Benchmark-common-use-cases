# ECS.CSharp.Benchmark - Common use-cases

Motivation of this benchmark project:

- Compare performance of common uses cases of multiple ECS projects.  
  *"I want to compare the performance of two C# ECS projects"?*  
  Use the example command shown in the [Benchmark CLI](#benchmark-cli) examples below.

- Utilize a common ECS operation of a specific ECS project in most **simple & performant** way.  

- *"I want to migrate from one C# ECS to another"?*  
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
  - [Basic](#basic)
  - [Relations](#relations)
  - [Command buffer](#command-buffer)
  - [Events](#events)
  - [Search](#search)
* [Setup](#setup)
* [Contribution](#contribution)
* [Benchmark CLI](#benchmark-cli)

<br/>

## Tested projects

Ordered by GitHub Activity

| ECS                                                                                           | ECS implementation      | Entity | tested            | nuget
|---------------------------------------------------------------------------------------------- | ----------------------- | -------| ----------------- | ------
| [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)   | Archetype               | struct | 3.0.0-preview.2   | [![nuget](https://img.shields.io/nuget/vpre/Friflo.Engine.ECS?color=blue)](https://www.nuget.org/packages/Friflo.Engine.ECS)
| [fennecs](https://github.com/thygrrr/fennecs)                                                 | Archetype               | struct | 0.5.8-beta        | [![nuget](https://img.shields.io/nuget/vpre/fennecs?color=blue)](https://www.nuget.org/packages/fennecs)
| [TinyEcs](https://github.com/andreakarasho/TinyEcs)                                           | Archetype               | struct | 1.3.0             | [![nuget](https://img.shields.io/nuget/v/TinyEcs.Main?color=blue)](https://www.nuget.org/packages/TinyEcs.Main)
| [Flecs.NET](https://github.com/BeanCheeseBurrito/Flecs.NET)                                   | Archetype / Sparse Set  | struct | 4.0.0             | [![nuget](https://img.shields.io/nuget/v/Flecs.NET.Release?color=blue)](https://www.nuget.org/packages/Flecs.NET.Release)
| [Arch](https://github.com/genaray/Arch)                                                       | Archetype               | struct | 1.2.8             | [![nuget](https://img.shields.io/nuget/v/Arch?color=blue)](https://www.nuget.org/packages/Arch)
| [Morpeh](https://github.com/scellecs/morpeh)                                                  | ?                       | class  | 2023.1.0          | [![nuget](https://img.shields.io/nuget/v/Scellecs.Morpeh?color=blue)](https://www.nuget.org/packages/Scellecs.Morpeh)
| [Leopotam.EcsLite](https://github.com/Leopotam/ecslite)                                       | Sparse Set              | int    | 1.0.1             | [![nuget](https://img.shields.io/nuget/v/Leopotam.EcsLite?color=blue)](https://www.nuget.org/packages/Leopotam.EcsLite) ⁽¹⁾
| [DefaultEcs](https://github.com/Doraku/DefaultEcs)                                            | Sparse Set              | struct | 0.18.0-beta01     | [![nuget](https://img.shields.io/nuget/vpre/DefaultEcs?color=blue)](https://www.nuget.org/packages/DefaultEcs)

⁽¹⁾ nuget package not published by project owner


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

## Feature Matrix

| ECS               | Basic | Relations | Command Buffer | Events | Search |
|------------------ |:-----:|:---------:|:--------------:|:------:|:------:|
| Arch              |  ✅  |           |       ✅       |        |        |
| DefaultEcs        |  ✅  |           |       ✅       |  ✅    |        |
| fennecs           |  ✅  |    ✅     |                |        |        |
| Flecs.NET         |  ✅  |    ✅     |       ✅      |   ✅   |        |
| Friflo.Engine.ECS |  ✅  |    ✅     |       ✅      |   ✅   |   ✅   |
| Leopotam.EcsLite  |  ✅  |           |                |         |        |
| Morpeh            |  ✅  |           |      ✅        |        |        |
| TinyEcs           |  ✅  |    ✅     |       ✅      |   ✅   |        |

<br/>

| Benchmark Category                                     | Category id                                     |
|------------------------------------------------------- | ----------------------------------------------- |
| [**Basic**](#basic)                                    |                                                 |
| Add & Remove 1/3 components on 100 entities            | `AddRemoveComponentsT1` `AddRemoveComponentsT5` |
| Create 100.000 entities with 1/3 components            | `CreateEntityT1` `CreateEntityT3`               |
| Create world                                           | `CreateWorld`                                   |
| Delete 100.000 entities with 5 components              | `DeleteEntity`                                  |
| Get & Set 1 component on 100 entities                  | `GetSetComponentsT1`                            |
| Query 100 entities with 1/5 components                 | `QueryT1` `QueryT5`                             |
|                                                        |                                                 |
| [**Relations**](#relations)                            |                                                 |
| Add & Remove 1/100 link relation on 100 entities       | `AddRemoveLinks` `TargetCount`: 1/100           |
|                                                        |                                                 |
| [**Command Buffer**](#command-buffer)                  |                                                 |
| Add & Remove 2 components on 100 entities              | `CommandBufferAddRemoveT2`                      |
|                                                        |                                                 |
| [**Events**](#events)                                  |                                                 |
| Get event callback on Add & Remove component           | `ComponentEvents`                               |
|                                                        |                                                 |
| [**Search**](#search)                                  |                                                 |
| Search component field in 1.000.000 entities           | `SearchComponentField`                          |
| Search range of component fields in 1.000.000 entities | `SearchRange`                                   |

<br/>

Run benchmarks always on an **Apple Mac Mini M2**.  
Its hardware specs are fixed and can be compared with benchmarks you run by your own on this machine.

```
BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
```

## **Basic**

### Add & Remove 1 component on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |        977 ns |     0.17 |           - | 
| DefaultEcs        |      1,435 ns |     0.25 |           - | 
| Scellecs.Morpeh   |      1,829 ns |     0.32 |           - | 
| Flecs.NET         |      2,924 ns |     0.51 |           - | 
| Friflo.Engine.ECS |      5,706 ns |     1.00 |           - | 
| Arch              |      8,671 ns |     1.52 |     12000 B | 
| TinyEcs           |     11,945 ns |     2.09 |      6400 B | 
| fennecs           |     38,592 ns |     6.76 |     86400 B | 


### Add & Remove 5 components on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,133 ns |     0.66 |           - | 
| DefaultEcs        |      7,246 ns |     0.93 |           - | 
| Scellecs.Morpeh   |      7,605 ns |     0.98 |           - | 
| Friflo.Engine.ECS |      7,780 ns |     1.00 |           - | 
| Arch              |     22,366 ns |     2.87 |      8800 B | 
| Flecs.NET         |     31,669 ns |     4.07 |           - | 
| TinyEcs           |     86,149 ns |    11.07 |     64000 B | 
| fennecs           |    305,012 ns |    39.20 |    620800 B | 


### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    398,582 ns |     1.00 |   3449408 B | 
| fennecs           |    864,422 ns |     2.15 |   6815576 B | 
| Flecs.NET         |  1,323,135 ns |     3.32 |       736 B | 
| Leopotam.EcsLite  |  1,966,467 ns |     4.88 |   7316032 B | 
| Arch              |  5,260,709 ns |    13.21 |      3088 B | 
| DefaultEcs        |  6,601,481 ns |    16.38 |  11592448 B | 
| TinyEcs           |  6,755,046 ns |    16.78 |  10118352 B | 
| Scellecs.Morpeh   | 42,849,157 ns |   106.38 |  42293152 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    453,287 ns |     1.00 |   4498032 B | 
| fennecs           |    934,082 ns |     2.06 |   7866864 B | 
| Flecs.NET         |  1,462,341 ns |     3.22 |       736 B | 
| Arch              |  1,855,739 ns |     4.08 |      3088 B | 
| Leopotam.EcsLite  |  2,624,818 ns |     5.89 |  11498680 B | 
| DefaultEcs        |  5,790,311 ns |    12.99 |  19984528 B | 
| TinyEcs           | 23,360,839 ns |    51.56 |  23921880 B | 
| Scellecs.Morpeh   | 29,691,392 ns |    65.51 |  49284080 B | 


### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         72 ns |     0.34 |       336 B | 
| Friflo.Engine.ECS |        216 ns |     1.00 |      3584 B | 
| Leopotam.EcsLite  |      1,463 ns |     6.77 |     58944 B | 
| Arch              |      3,392 ns |    15.70 |     37040 B | 
| Scellecs.Morpeh   |      4,296 ns |    19.88 |      5056 B | 
| fennecs           |     15,120 ns |    69.95 |    169796 B | 
| TinyEcs           |     33,251 ns |   153.85 |    889424 B | 
| Flecs.NET         |  1,000,598 ns | 4,629.00 |      1009 B | 


### Delete 100.000 entities with 5 components

**Note:** The allocations comes from the fact that the buffers used to store components are replaced by smaller buffers over time.  
Without this behavior the component buffers allocated by the ECS would never shrink.  
In case of Flecs.NET components are store in native heap which is not monitored by BenchmarkDotNet.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,551,068 ns |     1.00 |   3122896 B | 
| Flecs.NET         |  1,993,240 ns |     1.29 |       736 B | 
| Arch              |  2,635,788 ns |     1.70 |      3088 B | 
| DefaultEcs        |  3,734,260 ns |     2.42 |   3200736 B | 
| Leopotam.EcsLite  |  4,553,305 ns |     2.94 |   6268768 B | 
| fennecs           |  5,827,321 ns |     3.76 |   4366912 B | 
| Scellecs.Morpeh   |  8,721,128 ns |     5.41 |   1398360 B | 
| TinyEcs           |286,001,355 ns |   184.49 | 491139424 B | 


### Get & Set 1 component on 100 entities

**Note:** Sparse Set based ECS projects are in lead because of viewer array lookups.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.43 |           - | 
| DefaultEcs        |        111 ns |     0.74 |           - | 
| Friflo.Engine.ECS |        151 ns |     1.00 |           - | 
| Arch              |        279 ns |     1.84 |           - | 
| Scellecs.Morpeh   |        329 ns |     2.17 |           - | 
| Flecs.NET         |        581 ns |     3.84 |           - | 
| fennecs           |      2,420 ns |    15.98 |           - | 
| TinyEcs           |      2,481 ns |    16.38 |           - | 


### Query 100 entities with 1 component

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         45 ns |     0.99 |           - | 
| Friflo.Engine.ECS |         45 ns |     1.00 |           - | 
| TinyEcs           |         65 ns |     1.44 |           - | 
| Leopotam.EcsLite  |         76 ns |     1.68 |           - | 
| Arch              |        120 ns |     2.64 |           - | 
| Flecs.NET         |        142 ns |     3.13 |           - | 
| fennecs           |        170 ns |     3.75 |        40 B | 
| Scellecs.Morpeh   |        313 ns |     6.87 |           - | 


### Query 100 entities with 5 components

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |        111 ns |     1.00 |           - | 
| TinyEcs           |        115 ns |     1.03 |           - | 
| Arch              |        196 ns |     1.77 |           - | 
| Flecs.NET         |        198 ns |     1.79 |           - | 
| DefaultEcs        |        271 ns |     2.45 |           - | 
| Leopotam.EcsLite  |        345 ns |     3.11 |           - | 
| fennecs           |        407 ns |     3.66 |        40 B | 
| Scellecs.Morpeh   |        783 ns |     7.04 |           - | 

<br/>


## **Relations**

Some ECS projects have support for [Entity Relationships](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#entity-relationships).

Relations enable to create *directed* links between entities aka entity relationships.  
*Directed link* means that a link points from a source entity to a target entity.  
A single entity can have multiple links to other target entities.

### Add & Remove 1 link relation on 100 entities

| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | 1           |       5 μs |  1.00 |          - | 
| Flecs.NET         | 1           |      10 μs |  2.01 |          - | 
| TinyEcs           | 1           |      28 μs |  5.58 |    22400 B | 
| fennecs           | 1           |      92 μs | 18.07 |   180000 B | 


### Add & Remove 100 link relations on 100 entities

| ECS               | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |------------ |-----------:|------:|------------:|
| Flecs.NET         | 100         |     947 μs |  0.82 |        1 B | 
| Friflo.Engine.ECS | 100         |   1,158 μs |  1.00 |        1 B | 
| TinyEcs           | 100         |   8,776 μs |  7.57 | 18080012 B | 
| fennecs           | 100         |  70,384 μs | 60.74 | 93124892 B | 

<br/>


## **Command buffer**

A command buffer is used to record entity changes in a buffer.  
While recording the state of entities remains unchanged.  
These changes are applied to these entities when calling either   
`Playback()`, `Execute()`, `Commit()` or `DeferEnd()`

### Add & Remove 2 components on 100 entities using a command buffer

1. Add components.    Apply changes.
2. Remove components. Apply changes.

| ECS               |  Mean     | Ratio | Allocated | 
|------------------ |----------:|------:|----------:|
| Scellecs.Morpeh   |   4.95 μs |  0.58 |         - | 
| Friflo.Engine.ECS |   8.62 μs |  1.00 |         - | 
| Flecs.NET         |   9.81 μs |  1.14 |         - | 
| DefaultEcs        |  16.28 μs |  1.89 |         - | 
| TinyEcs           |  29.37 μs |  3.41 |   20800 B | 
| Arch              |  46.29 μs |  5.37 |    4800 B | 

<br/>


## **Events**

ECS implementations supporting callbacks for specific events are called **reactive**.  
Typical event types are:
- Add / Update / Remove component
- Add / Remove tag
- Create / Delete entity

### Get callback event on Add & Remove component on 100 entities

| ECS               |  Mean     | Ratio | Allocated | 
|------------------ |----------:|------:|----------:|
| DefaultEcs        |   2.56 μs |  0.34 |         - | 
| Friflo.Engine.ECS |   7.57 μs |  1.00 |         - | 
| Flecs.NET         |  10.37 μs |  1.37 |         - | 
| TinyEcs           |  13.83 μs |  1.83 |    6400 B | 

<br/>


## **Search**

A search can be used to get all entities with a specific component field value.  
This type of search is typically executed in O(1) .  
E.g. to find all entities having a `Player` component where `Player.name == "Bob"`
```
struct Player { string name; } 
```

A search can also be used for range queries to find all entities with a component field value in a [min, max] range.  
E.g. a range query return all entities with a `Health` component where `Health.value` is between 10 and 100.
```
struct Health { int value; } 
```

Search and Range Queries of component fields are explained at this [GitHub ⋅ Wiki page](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#search).

### Search component field in 1.000.000 entities

Execute 1000 searches for different search values in a data set of 1.000.000 entities.  
Each result has 1 match.

| ECS               |  Mean         | Ratio | Allocated | 
|------------------ |--------------:|------:|----------:|
| Friflo.Engine.ECS |       4.71 μs |  1.00 |         - | 


### Search range of component fields in 1.000.000 entities

Execute 1000 range queries with different [min, max] in a data set of 1.000.000 entities.  
Each result has 100 matches.

| ECS               |  Mean         | Ratio | Allocated | 
|------------------ |--------------:|------:|----------:|
| Friflo.Engine.ECS |   1,328.12 μs |  1.00 |  560001 B | 

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
- The Project builds with `<AllowUnsafeBlocks>false</AllowUnsafeBlocks>`. See [ECS.Benchmark.csproj](src/ECS.Benchmark.csproj).

The benchmarks `CreateEntity` and `DeleteEntity` are changing the state of World which has influence on the benchmark measurement.  
If executing their `[Benchmark]` method multiple times the number of entities will grow / shrink for each method iteration.  
This would slow down the execution over time and give wrong measurement results.  
To avoid this these benchmarks are executed with 100.000 entities every time on a new World instance.


# Contribution

Contributions are welcome.  
Only requirement: Ensure it compiles.

- *How to add a single benchmark*?  
  Copy an existing benchmark and make adaptations.

- *How to add benchmarks for a new ECS project*?  
  Copy an existing project and make adaptations.

- *Adding a new benchmark category*?  
  Open a new issue or discussion to explain the feature.


# Benchmark CLI

**CLI benchmark example commands**

### Windows CLI

```php
cd ./src

dotnet run -c Release --filter *                                # run all benchmarks
dotnet run -c Release --filter *AddRemoveComponentsT1_Friflo*   # run a specific benchmark
dotnet run -c Release --filter *AddRemoveComponents*            # run benchmarks of single category
dotnet run -c Release --filter *Friflo*                         # run benchmarks of single project
dotnet run -c Release --filter *Friflo* *Arch*                  # compare benchmarks of two projects

# run basic benchmarks
dotnet run -c Release --filter *AddRemoveComponents* *GetSetComponents* *CreateEntity* *CreateWorld* *DeleteEntity* *Query*
dotnet run -c Release --filter *AddRemoveLinks*                 # run relations benchmarks
dotnet run -c Release --filter *CommandBuffer*                  # run command buffer benchmarks
dotnet run -c Release --filter *Events*                         # run component events benchmarks
dotnet run -c Release --filter *Search*                         # run search benchmarks
```

### macOS CLI

```php
cd ./src

dotnet run -c Release --filter \*                               # run all benchmarks
dotnet run -c Release --filter \*AddRemoveComponentsT1_Friflo\* # run a specific benchmark
dotnet run -c Release --filter \*AddRemoveComponents\*          # run benchmarks of single category
dotnet run -c Release --filter \*Friflo\*                       # run benchmarks of single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*              # compare benchmarks of two projects

# run basic benchmarks
dotnet run -c Release --filter \*AddRemoveComponents\* \*GetSetComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*AddRemoveLinks\*               # run relations benchmarks
dotnet run -c Release --filter \*CommandBuffer\*                # run command buffer benchmarks
dotnet run -c Release --filter \*Events\*                       # run component events benchmarks
dotnet run -c Release --filter \*Search\*                       # run search benchmarks
```

