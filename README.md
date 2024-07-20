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

All tested projects are engine agnostic.  
Ordered by GitHub Activity

| ECS                                                                                           | ECS implementation      | Entity | tested            | nuget
|---------------------------------------------------------------------------------------------- | ----------------------- | -------| ----------------- | ------
| [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)   | Archetype               | struct | 3.0.0-preview.2   | [![nuget](https://img.shields.io/nuget/vpre/Friflo.Engine.ECS?color=blue)](https://www.nuget.org/packages/Friflo.Engine.ECS)
| [fennecs](https://github.com/thygrrr/fennecs)                                                 | Archetype               | struct | 0.5.8-beta        | [![nuget](https://img.shields.io/nuget/vpre/fennecs?color=blue)](https://www.nuget.org/packages/fennecs)
| [TinyEcs](https://github.com/andreakarasho/TinyEcs)                                           | Archetype               | struct | 1.4.0             | [![nuget](https://img.shields.io/nuget/v/TinyEcs.Main?color=blue)](https://www.nuget.org/packages/TinyEcs.Main)
| [Flecs.NET](https://github.com/BeanCheeseBurrito/Flecs.NET)                                   | Archetype / Sparse Set  | struct | 4.0.0             | [![nuget](https://img.shields.io/nuget/v/Flecs.NET.Release?color=blue)](https://www.nuget.org/packages/Flecs.NET.Release)
| [Arch](https://github.com/genaray/Arch)                                                       | Archetype               | struct | 1.2.8             | [![nuget](https://img.shields.io/nuget/v/Arch?color=blue)](https://www.nuget.org/packages/Arch)
| [Arch.Relationships](https://github.com/genaray/Arch.Extended)                                | add-on                  |        | 1.0.1             | [![nuget](https://img.shields.io/nuget/v/Arch.Relationships?color=blue)](https://www.nuget.org/packages/Arch.Relationships)
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

- **Heap**
    - **m** - **managed memory**: Memory is managed by dotnet runtime.  
    BenchmarkDotNet monitors allocations of this memory in column: **Allocated**.  
    Access to managed memory is slower than to native memory when boundary checks are needed.

    - **n** - **native memory**: Memory is allocated and managed by the ECS.  
    BenchmarkDotNet does not monitor allocations of native memory.  
    Bugs in game code or ECS related to native memory may result in memory corruption / access violation.
- **Watch** - Watch entity components in debugger


| ECS                  | Basic | Relations | Command Buffer | Events | Search | Heap | Watch  |
|--------------------- |:-----:|:---------:|:--------------:|:------:|:------:|------|:------:|
| Arch + Relationships |  ✅  |    ✅     |       ✅       |  [^1]  |        | m, n |   ✅  |
| DefaultEcs           |  ✅  |           |       ✅       |  ✅    |        | m, n |   ✅  |
| fennecs              |  ✅  |    ✅     |                |  [^2]  |        | m, n |   ✅  |
| Flecs.NET            |  ✅  |    ✅     |       ✅      |   ✅   |        | m, n |        |
| Friflo.Engine.ECS    |  ✅  |    ✅     |       ✅      |   ✅   |   ✅   | m    |   ✅  |
| Leopotam.EcsLite     |  ✅  |           |                |         |        | m, n |       |
| Morpeh               |  ✅  |           |       ✅       |        |        | m, n |        |
| TinyEcs              |  ✅  |    ✅     |       ✅      |   ✅   |        | m, n |        |

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
| Leopotam.EcsLite  |        971 ns |     0.17 |           - | 
| DefaultEcs        |      1,445 ns |     0.25 |           - | 
| Scellecs.Morpeh   |      1,837 ns |     0.32 |           - | 
| Flecs.NET         |      2,918 ns |     0.51 |           - | 
| TinyEcs           |      3,974 ns |     0.70 |           - | 
| Friflo.Engine.ECS |      5,686 ns |     1.00 |           - | 
| Arch              |      8,395 ns |     1.48 |     12000 B | 
| fennecs           |     38,885 ns |     6.84 |     86400 B | 


### Add & Remove 5 components on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,142 ns |     0.66 |           - | 
| DefaultEcs        |      7,341 ns |     0.95 |           - | 
| Scellecs.Morpeh   |      7,660 ns |     0.99 |           - | 
| Friflo.Engine.ECS |      7,738 ns |     1.00 |           - | 
| Arch              |     22,302 ns |     2.88 |      8800 B | 
| TinyEcs           |     30,544 ns |     3.95 |           - | 
| Flecs.NET         |     31,677 ns |     4.09 |           - | 
| fennecs           |    303,744 ns |    39.25 |    620800 B | 


### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    398,502 ns |     1.00 |   3454080 B | 
| fennecs           |    860,255 ns |     2.16 |   6815576 B | 
| TinyEcs           |    954,571 ns |     2.39 |   6119312 B | 
| Flecs.NET         |  1,348,831 ns |     3.36 |       736 B | 
| Leopotam.EcsLite  |  1,985,066 ns |     4.98 |   7322344 B | 
| DefaultEcs        |  6,542,680 ns |    16.39 |  11592432 B | 
| Arch              | 10,317,988 ns |    25.90 |   3255040 B | 
| Scellecs.Morpeh   | 42,607,448 ns |   106.71 |  42293640 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    452,133 ns |     1.00 |   4506960 B | 
| fennecs           |    931,711 ns |     2.06 |   7866864 B | 
| TinyEcs           |    989,726 ns |     2.18 |   6942912 B | 
| Flecs.NET         |  1,499,024 ns |     3.32 |       736 B | 
| Leopotam.EcsLite  |  2,569,402 ns |     5.66 |  11517616 B | 
| DefaultEcs        |  5,919,036 ns |    13.04 |  19984528 B | 
| Arch              | 10,572,175 ns |    23.30 |   4042736 B | 
| Scellecs.Morpeh   | 29,225,251 ns |    64.62 |  49285544 B | 


### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         73 ns |     0.35 |       336 B | 
| Friflo.Engine.ECS |        212 ns |     1.00 |      3592 B | 
| Leopotam.EcsLite  |      1,447 ns |     6.82 |     58944 B | 
| Arch              |      3,367 ns |    15.86 |     37040 B | 
| Scellecs.Morpeh   |      4,297 ns |    20.25 |      5056 B | 
| fennecs           |     15,205 ns |    71.63 |    169796 B | 
| TinyEcs           |     50,746 ns |   238.96 |   1312184 B | 
| Flecs.NET         |    967,689 ns | 4,556.67 |      1009 B | 


### Delete 100.000 entities with 5 components

**Note:**  
The high amount of allocations is an indicator that buffers used to store components are replaced by smaller buffers over time.  
Without this behavior the component buffers allocated by the ECS would never shrink.  
In case of Flecs.NET components are store in native heap which is not monitored by BenchmarkDotNet.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,599,785 ns |     1.00 |   3122896 B | 
| Flecs.NET         |  1,986,746 ns |     1.24 |       736 B | 
| Arch              |  2,649,192 ns |     1.65 |      3088 B | 
| TinyEcs           |  3,308,196 ns |     2.09 |      1480 B | 
| DefaultEcs        |  3,713,867 ns |     2.36 |   3200736 B | 
| Leopotam.EcsLite  |  4,718,733 ns |     2.96 |   6268768 B | 
| fennecs           |  5,749,906 ns |     3.60 |   4366912 B | 
| Scellecs.Morpeh   |  9,084,572 ns |     5.57 |   1398360 B | 


### Get & Set 1 component on 100 entities

**Note:** Sparse Set based ECS projects are in lead because of viewer array lookups.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.43 |           - | 
| DefaultEcs        |        111 ns |     0.74 |           - | 
| Friflo.Engine.ECS |        151 ns |     1.00 |           - | 
| Arch              |        282 ns |     1.87 |           - | 
| Scellecs.Morpeh   |        328 ns |     2.17 |           - | 
| Flecs.NET         |        581 ns |     3.85 |           - | 
| TinyEcs           |        716 ns |     4.74 |           - | 
| fennecs           |      2,368 ns |    15.66 |           - | 


### Query 100 entities with 1 component

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |      44.73 ns |     0.95 |           - | 
| Friflo.Engine.ECS |      47.33 ns |     1.00 |           - | 
| TinyEcs           |      65.65 ns |     1.39 |           - | 
| Leopotam.EcsLite  |      76.44 ns |     1.61 |           - | 
| Arch              |     119.41 ns |     2.52 |           - | 
| Flecs.NET         |     142.13 ns |     3.00 |           - | 
| fennecs           |     166.64 ns |     3.52 |        40 B | 
| Scellecs.Morpeh   |     308.90 ns |     6.53 |           - | 

⁽¹⁾ Queries on components with reference type fields (e.g. string) require less performant query iteration.  
This specific case is not benchmarked.

### Query 100 entities with 5 components

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |     109.31 ns |     1.00 |           - | 
| TinyEcs           |     122.91 ns |     1.12 |           - | 
| Flecs.NET         |     197.48 ns |     1.80 |           - | 
| Arch              |     198.85 ns |     1.82 |           - | 
| DefaultEcs        |     270.89 ns |     2.48 |           - | 
| Leopotam.EcsLite  |     344.38 ns |     3.15 |           - | 
| fennecs           |     417.77 ns |     3.84 |        40 B | 
| Scellecs.Morpeh   |     787.49 ns |     7.20 |           - | 

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

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 1             |     5,158 ns |     1.00 |          - | 
| Flecs.NET         | 1             |    10,405 ns |     2.02 |          - | 
| TinyEcs           | 1             |    15,944 ns |     3.09 |          - | 
| Arch              | 1             |    67,361 ns |    13.06 |    36800 B | 
| fennecs           | 1             |    93,101 ns |    18.05 |   180000 B | 
 

### Add & Remove 100 link relations on 100 entities

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Flecs.NET         | 100           |   958,910 ns |     0.82 |        1 B | 
| Friflo.Engine.ECS | 100           | 1,172,994 ns |     1.00 |        1 B | 
| Arch              | 100           | 4,185,699 ns |     3.57 |  2180006 B | 
| TinyEcs           | 100           | 4,206,844 ns |     3.59 |        8 B | 
| fennecs           | 100           |71,216,263 ns |    60.71 | 93124905 B | 

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
- **Arch.Relationships**        - An additional entity with a component is used as discriminator.
- **fennecs**                   - Reference type instances are used as discriminator.

### Add & Remove 1 relation on 100 entities

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 1             |     3,113 ns |     1.00 |          - | 
| Flecs.NET         | 1             |    11,897 ns |     3.82 |          - | 
| TinyEcs           | 1             |    23,450 ns |     7.53 |          - | 
| Arch              | 1             |    43,913 ns |    14.10 |    36800 B | 
| fennecs           | 1             |    96,208 ns |    30.90 |   180000 B | 


### Add & Remove 10 relations on 100 entities

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 10            |    47,820 ns |     1.00 |          - | 
| Flecs.NET         | 10            |   155,591 ns |     3.25 |          - | 
| Arch              | 10            |   198,107 ns |     4.14 |   240800 B | 
| TinyEcs           | 10            |   283,759 ns |     5.93 |        1 B | 
| fennecs           | 10            | 1,564,173 ns |    32.71 |  2568001 B | 

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
| Scellecs.Morpeh   |  5,002 ns |     0.59 |          - | 
| Friflo.Engine.ECS |  8,538 ns |     1.00 |          - | 
| Flecs.NET         |  9,829 ns |     1.15 |          - | 
| TinyEcs           | 13,081 ns |     1.53 |     4800 B | 
| DefaultEcs        | 16,153 ns |     1.89 |          - | 
| Arch              | 46,801 ns |     5.48 |     4800 B |  

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
| DefaultEcs        |  2,582 ns |     0.33 |          - | 
| TinyEcs           |  4,422 ns |     0.57 |          - | 
| Friflo.Engine.ECS |  7,749 ns |     1.00 |          - | 
| Flecs.NET         | 10,474 ns |     1.35 |          - | 

[^1]:  Arch: Support for events requires a custom build. Performance of component related benchmarks will decrease.
[^2]:  fennecs: Support for events is planned according to its project README.

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

