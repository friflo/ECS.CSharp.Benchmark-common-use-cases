[![Benchmark-CI](https://img.shields.io/github/actions/workflow/status/friflo/ECS.CSharp.Benchmark-common-use-cases/.github/workflows/benchmark-ci.yml?label=Benchmark-CI)](https://github.com/friflo/ECS.CSharp.Benchmark-common-use-cases/actions/workflows/benchmark-ci.yml)
[![Benchmark Archive](https://img.shields.io/badge/Benchmark-Archive-blue)](https://github.com/friflo/ECS.CSharp.Benchmark-common-use-cases/tree/main/results/mac-mini-m2)

# ECS.CSharp.Benchmark - Common use-cases

Motivation of this benchmark project:

- Compare performance of common uses cases of multiple ECS projects.  
  *"I want to compare the performance of two C# ECS projects"?*  
  Use the example command shown in the [Benchmark CLI](#benchmark-cli) examples below.

- Utilize a common ECS operation of a specific ECS project in most **simple & performant** way.  

- *"I want to migrate from one C# ECS to another"?*  
  Navigate to a specific benchmark in both projects an use their implementations as migration guide.  
  Benchmark implementations are intended to be as simple as possible.

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

All tested project are engine agnostic.  
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

| ECS               | Basic | Relations | Command Buffer | Events | Search | Heap | Watch  |
|------------------ |:-----:|:---------:|:--------------:|:------:|:------:|------|:------:|
| Arch              |  ✅  |           |       ✅       |        |        | m, n |   ✅  |
| DefaultEcs        |  ✅  |           |       ✅       |  ✅    |        | m, n |   ✅  |
| fennecs           |  ✅  |    ✅     |                |        |        | m, n |   ✅  |
| Flecs.NET         |  ✅  |    ✅     |       ✅      |   ✅   |        | m, n |        |
| Friflo.Engine.ECS |  ✅  |    ✅     |       ✅      |   ✅   |   ✅   | m    |   ✅  |
| Leopotam.EcsLite  |  ✅  |           |                |         |        | m, n |       |
| morpeh            |  ✅  |           |       ✅       |        |        | m, n |        |
| TinyEcs           |  ✅  |    ✅     |       ✅      |   ✅   |        | m, n |        |

- Watch - Watch entity components in debugger
- Heap
    - **m** - **managed memory**: Memory is managed by dotnet runtime.  
    BenchmarkDotNet monitors allocations of this memory in column: Allocated.  
    Access to managed memory is slower than to native memory when boundary checks are needed.

    - **n** - **native memory**: Memory is allocated and managed by the ECS.  
    BenchmarkDotNet does not monitor allocations of native memory.  
    Bugs in game code or ECS related to native memory may result in memory corruption / access violation.


<br/>

| Benchmark Category                                            | Category id                                     |
|-------------------------------------------------------------- | ----------------------------------------------- |
| [**Basic**](#basic)                                           |                                                 |
| Add & Remove 1/3 components on 100 entities                   | `AddRemoveComponentsT1` `AddRemoveComponentsT5` |
| Create 100.000 entities with 1/3 components                   | `CreateEntityT1` `CreateEntityT3`               |
| Create world                                                  | `CreateWorld`                                   |
| Delete 100.000 entities with 5 components                     | `DeleteEntity`                                  |
| Get & Set 1 component on 100 entities                         | `GetSetComponentsT1`                            |
| Query 100 entities with 1/5 components                        | `QueryT1` `QueryT5`                             |
|                                                               |                                                 |
| [**Relations**](#relations)                                   |                                                 |
| Add & Remove 1/100 link relation on 100 entities              | `AddRemoveLinks`     `RelationCount`: 1/100     |
| Add & Remove 1/10 relations on 100 entities                   | `AddRemoveRelations` `RelationCount`: 1/10      |
|                                                               |                                                 |
| [**Command Buffer**](#command-buffer) - *deferred operations* |                                                 |
| Add & Remove 2 components on 100 entities                     | `CommandBufferAddRemoveT2`                      |
|                                                               |                                                 |
| [**Events**](#events) - *reactive ECS*                        |                                                 |
| Get event callback on Add & Remove component                  | `ComponentEvents`                               |
|                                                               |                                                 |
| [**Search**](#search)                                         |                                                 |
| Search component field in 1.000.000 entities                  | `SearchComponentField`                          |
| Search range of component fields in 1.000.000 entities        | `SearchRange`                                   |

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
| Leopotam.EcsLite  |        976 ns |     0.17 |           - | 
| DefaultEcs        |      1,461 ns |     0.26 |           - | 
| Scellecs.Morpeh   |      1,834 ns |     0.33 |           - | 
| Flecs.NET         |      2,931 ns |     0.52 |           - | 
| Friflo.Engine.ECS |      5,636 ns |     1.00 |           - | 
| Arch              |      8,677 ns |     1.54 |     12000 B | 
| TinyEcs           |     12,071 ns |     2.14 |      6400 B | 
| fennecs           |     38,996 ns |     6.92 |     86400 B | 


### Add & Remove 5 components on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,129 ns |     0.67 |           - | 
| DefaultEcs        |      7,218 ns |     0.94 |           - | 
| Scellecs.Morpeh   |      7,641 ns |     0.99 |           - | 
| Friflo.Engine.ECS |      7,691 ns |     1.00 |           - | 
| Arch              |     21,984 ns |     2.86 |      8800 B | 
| Flecs.NET         |     30,191 ns |     3.93 |           - | 
| TinyEcs           |     85,659 ns |    11.13 |     64001 B | 
| fennecs           |    326,645 ns |    42.47 |    620800 B | 


### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    391,076 ns |     1.00 |   3449408 B | 
| fennecs           |    876,606 ns |     2.24 |   6815576 B | 
| Flecs.NET         |  1,303,024 ns |     3.32 |       736 B | 
| Leopotam.EcsLite  |  1,976,172 ns |     5.05 |   7316032 B | 
| Arch              |  5,230,890 ns |    13.48 |      3088 B | 
| DefaultEcs        |  6,565,510 ns |    16.79 |  11592432 B | 
| TinyEcs           |  6,826,935 ns |    17.46 |  10118352 B | 
| Scellecs.Morpeh   | 42,953,791 ns |   109.89 |  42293184 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    448,975 ns |     1.00 |   4498032 B | 
| fennecs           |    937,536 ns |     2.07 |   7866864 B | 
| Flecs.NET         |  1,464,115 ns |     3.24 |       736 B | 
| Leopotam.EcsLite  |  2,633,338 ns |     5.91 |  11498680 B | 
| Arch              |  5,395,988 ns |    11.90 |      3088 B | 
| DefaultEcs        |  5,774,491 ns |    12.90 |  19984528 B | 
| TinyEcs           | 23,657,636 ns |    52.30 |  23921880 B | 
| Scellecs.Morpeh   | 29,805,461 ns |    65.76 |  49284080 B | 


### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         72 ns |     0.33 |       336 B | 
| Friflo.Engine.ECS |        216 ns |     1.00 |      3592 B | 
| Leopotam.EcsLite  |      1,446 ns |     6.69 |     58944 B | 
| Arch              |      3,380 ns |    15.64 |     37040 B | 
| Scellecs.Morpeh   |      4,286 ns |    19.83 |      5056 B | 
| fennecs           |     15,301 ns |    70.79 |    169796 B | 
| TinyEcs           |     34,447 ns |   159.35 |    889424 B | 
| Flecs.NET         |    979,837 ns | 4,532.77 |      1009 B | 


### Delete 100.000 entities with 5 components

**Note:** The allocations comes from the fact that the buffers used to store components are replaced by smaller buffers over time.  
Without this behavior the component buffers allocated by the ECS would never shrink.  
In case of Flecs.NET components are store in native heap which is not monitored by BenchmarkDotNet.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,613,736 ns |     1.00 |   3122896 B | 
| Flecs.NET         |  2,008,759 ns |     1.24 |       736 B | 
| Arch              |  2,684,300 ns |     1.66 |      3088 B | 
| DefaultEcs        |  3,686,282 ns |     2.29 |   3200736 B | 
| Leopotam.EcsLite  |  4,793,088 ns |     2.97 |   6268768 B | 
| fennecs           |  5,764,400 ns |     3.57 |   4366912 B | 
| Scellecs.Morpeh   |  8,046,867 ns |     4.99 |   1398360 B | 
| TinyEcs           |286,738,797 ns |   177.68 | 491139416 B | 


### Get & Set 1 component on 100 entities

**Note:** Sparse Set based ECS projects are in lead because of viewer array lookups.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.42 |           - | 
| DefaultEcs        |        111 ns |     0.72 |           - | 
| Friflo.Engine.ECS |        154 ns |     1.00 |           - | 
| Arch              |        282 ns |     1.83 |           - | 
| Scellecs.Morpeh   |        326 ns |     2.11 |           - | 
| Flecs.NET         |        581 ns |     3.76 |           - | 
| fennecs           |      2,426 ns |    15.68 |           - | 
| TinyEcs           |      2,460 ns |    15.91 |           - | 


### Query 100 entities with 1 component

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         44 ns |     0.95 |           - | 
| Friflo.Engine.ECS |         47 ns |     1.00 |           - | 
| TinyEcs           |         65 ns |     1.40 |           - | 
| Leopotam.EcsLite  |         76 ns |     1.62 |           - | 
| Arch              |        119 ns |     2.54 |           - | 
| Flecs.NET         |        142 ns |     3.03 |           - | 
| fennecs           |        166 ns |     3.53 |        40 B | 
| Scellecs.Morpeh   |        314 ns |     6.68 |           - | 


### Query 100 entities with 5 components

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |        111 ns |     1.00 |           - | 
| TinyEcs           |        119 ns |     1.07 |           - | 
| Arch              |        197 ns |     1.76 |           - | 
| Flecs.NET         |        207 ns |     1.85 |           - | 
| DefaultEcs        |        271 ns |     2.42 |           - | 
| Leopotam.EcsLite  |        339 ns |     3.03 |           - | 
| fennecs           |        404 ns |     3.62 |        40 B | 
| Scellecs.Morpeh   |        787 ns |     7.03 |           - | 

<br/>


## **Relations**

Some ECS projects have support for [Entity Relationships](https://github.com/friflo/Friflo.Json.Fliox/wiki/Examples-~-Component-Types#entity-relationships).  
Compared to relational databases: Entity relationships are similar to foreign keys referencing primary keys in other tables.
ECS implementations typically ensure [referential integrity](https://en.wikipedia.org/wiki/Referential_integrity).
This means there are never links to entities which doesn't exist.

Relations enable *directed* links between entities aka entity relationships.  
*Directed link* means that a link points from a source entity to a target entity.  
A single entity can have multiple links to other target entities.

### Add & Remove 1 link relation on 100 entities

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 1             |     5,079 ns |     1.00 |           - | 
| Flecs.NET         | 1             |    10,547 ns |     2.08 |           - | 
| TinyEcs           | 1             |    29,066 ns |     5.72 |     22400 B | 
| fennecs           | 1             |    94,018 ns |    18.51 |    180000 B | 


### Add & Remove 100 link relations on 100 entities

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Flecs.NET         | 100           |   946,965 ns |     0.81 |         1 B | 
| Friflo.Engine.ECS | 100           | 1,174,364 ns |     1.00 |         1 B | 
| TinyEcs           | 100           | 9,017,758 ns |     7.68 |  18080012 B | 
| fennecs           | 100           |71,485,885 ns |    60.87 |  93124892 B | 

<br/>

When dealing with an ECS following question arises at some point:  
*"Is it okay for performance to use an array, List<> or Dictionary<> as a component field"?*  
No, its not 😲. Now each component has a one or more reference types.  
As a result there is no cache locality anymore and GC requires much more CPU & memory resources.  
This is the reason why many ECS projects have relations.

A typical limitation of an ECS is that an entity can only contain one component of a certain type.  
Relations can be used to **add multiple components of the same type** to a single entity.  
To differentiate relations added to the same entity following mechanisms are used:

- **Friflo.Engine.ECS**         - A component field is used as discriminator specified in `IRelationComponent<TKey>`.
- **Flecs.NET** & **TinyEcs**   - Tags are used as discriminator.
- **fennecs**                   - Reference type instances are used as discriminator.

### Add & Remove 1 relation on 100 entities

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 1             |     3,083 ns |     1.00 |           - | 
| Flecs.NET         | 1             |     4,894 ns |     1.59 |           - | 
| TinyEcs           | 1             |    32,151 ns |    10.43 |     53600 B | 
| fennecs           | 1             |    40,777 ns |    13.22 |     86400 B | 


### Add & Remove 10 relations on 100 entities

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 10            |    48,452 ns |     1.00 |           - | 
| Flecs.NET         | 10            |   106,787 ns |     2.20 |           - | 
| TinyEcs           | 10            |   445,950 ns |     9.20 |    694400 B | 
| fennecs           | 10            |   977,793 ns |    20.18 |   1704801 B | 

<br/>


## **Command buffer**

A command buffer is used to record entity changes in a buffer.  
While recording the state of entities remains unchanged.  
These changes are applied to these entities when calling either   
`Playback()`, `Execute()`, `Commit()` or `DeferEnd()`

### Add & Remove 2 components on 100 entities using a command buffer

1. Add components.    Apply changes.
2. Remove components. Apply changes.

| ECS               | Mean      | Ratio    | Allocated   | 
|------------------ | ---------:|---------:|------------:|
| Scellecs.Morpeh   |  5,064 ns |     0.58 |           - | 
| Friflo.Engine.ECS |  8,736 ns |     1.00 |           - | 
| Flecs.NET         |  9,844 ns |     1.13 |           - | 
| DefaultEcs        | 16,674 ns |     1.91 |           - | 
| TinyEcs           | 29,329 ns |     3.36 |     20800 B | 
| Arch              | 48,425 ns |     5.54 |      4800 B | 

<br/>


## **Events**

ECS implementations supporting callbacks for specific events are called **reactive**.  
Typical event types are:
- Add / Update / Remove component
- Add / Remove tag
- Create / Delete entity

### Get callback event on Add & Remove component on 100 entities

| ECS               | Mean      | Ratio    | Allocated   | 
|------------------ | ---------:|---------:|------------:|
| DefaultEcs        |  2,602 ns |     0.35 |           - | 
| Friflo.Engine.ECS |  7,480 ns |     1.00 |           - | 
| Flecs.NET         | 10,419 ns |     1.39 |           - | 
| TinyEcs           | 13,781 ns |     1.84 |      6400 B | 

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

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ | -------------:| --------:| -----------:|
| Friflo.Engine.ECS |      4,875 ns |     1.00 |           - | 


### Search range of component fields in 1.000.000 entities

Execute 1000 range queries with different [min, max] in a data set of 1.000.000 entities.  
Each result has 100 matches.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ | -------------:| --------:| -----------:|
| Friflo.Engine.ECS |  1,343,502 ns |     1.00 |    560001 B | 

<br/>


# Setup

The benchmark project can be build and executed on **Windows**, **macOS** & **Linux**.  
All popular IDE's can be used to run and debug the project: **Rider**, **Visual Studio Code** & **Visual Studio**.

**Benchmark constraints**

- Each benchmark is **simple** and uses the fastest single threaded variant available.  
  To obtain clarity a project must not have multiple variants of the same benchmark type.
- Each Benchmark shares no state or code with any other benchmarks.
- Adding or removing a benchmark implementation has no effect on all others.
- Each project has an extension class `BenchUtils` with two methods to used by its benchmarks.  
  `BenchUtils.CreateEntities(int count)`  
  `BenchUtils.AddComponents(this Entity[] entities)`
- A package of the ECS must be available on nuget.
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

Currently ~ 100 benchmarks

- Running all benchmarks                    ~ 40 minutes
- Running all benchmarks with `--job Short` ~ 10 minutes
- Running all benchmarks with `--job Dry`   ~  1 minute (used by CI)

The published benchmarks are executed without: `--job` argument.  
The measurement difference when using `--job Short` were 2x in some benchmarks.  

For documentation of `--job` argument see [BenchmarkDotNet CLI args](https://github.com/dotnet/BenchmarkDotNet/blob/master/docs/articles/guides/console-args.md#more)

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
dotnet run -c Release --filter *Links* *Relations*              # run relation benchmarks
dotnet run -c Release --filter *CommandBuffer*                  # run command buffer benchmarks
dotnet run -c Release --filter *Events*                         # run component events benchmarks
dotnet run -c Release --filter *Search*                         # run search benchmarks
```

### macOS / Linux CLI

```php
cd ./src

dotnet run -c Release --filter \*                               # run all benchmarks
dotnet run -c Release --filter \*AddRemoveComponentsT1_Friflo\* # run a specific benchmark
dotnet run -c Release --filter \*AddRemoveComponents\*          # run benchmarks of single category
dotnet run -c Release --filter \*Friflo\*                       # run benchmarks of single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*              # compare benchmarks of two projects

# run basic benchmarks
dotnet run -c Release --filter \*AddRemoveComponents\* \*GetSetComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*Links\* \*Relations\*          # run relation benchmarks
dotnet run -c Release --filter \*CommandBuffer\*                # run command buffer benchmarks
dotnet run -c Release --filter \*Events\*                       # run component events benchmarks
dotnet run -c Release --filter \*Search\*                       # run search benchmarks
```

