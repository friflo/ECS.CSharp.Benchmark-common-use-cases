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

| ECS                                                                                           | ECS implementation      | Entity | tested            | nuget latest
|---------------------------------------------------------------------------------------------- | ----------------------- | -------| ----------------- | --------------------------------------
| [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)   | Archetype               | struct | 3.0.0-preview.3   | [![nuget](https://img.shields.io/nuget/vpre/Friflo.Engine.ECS?color=blue)](https://www.nuget.org/packages/Friflo.Engine.ECS)
| [fennecs](https://github.com/thygrrr/fennecs)                                                 | Archetype               | struct | 0.5.9-beta        | [![nuget](https://img.shields.io/nuget/vpre/fennecs?color=blue)](https://www.nuget.org/packages/fennecs)
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
| Add & Remove 10 child entities on 100 parent entities         | `ChildEntitiesAddRemove`                        |
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

Last benchmark update in README: **2024-07-20**

## **Basic**

### Add & Remove 1 component on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |        976 ns |     0.17 |          - | 
| DefaultEcs        |      1,449 ns |     0.26 |          - | 
| Scellecs.Morpeh   |      1,826 ns |     0.32 |          - | 
| Flecs.NET         |      3,755 ns |     0.67 |          - | 
| TinyEcs           |      3,948 ns |     0.70 |          - | 
| Friflo.Engine.ECS |      5,645 ns |     1.00 |          - | 
| Arch              |      8,557 ns |     1.52 |    12000 B | 
| fennecs           |     38,802 ns |     6.87 |    86400 B | 


### Add & Remove 5 components on 100 entities

**Note:** See impact of structural changes in Archetype based ECS projects.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |      5,148 ns |     0.68 |          - | 
| DefaultEcs        |      7,229 ns |     0.95 |          - | 
| Friflo.Engine.ECS |      7,598 ns |     1.00 |          - | 
| Scellecs.Morpeh   |      7,696 ns |     1.01 |          - | 
| Arch              |     22,557 ns |     2.97 |     8800 B | 
| TinyEcs           |     29,987 ns |     3.95 |          - | 
| Flecs.NET         |     35,145 ns |     4.63 |          - | 
| fennecs           |    306,849 ns |    40.39 |   620800 B | 


### Create 100.000 entities with 1 component

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    395,229 ns |     1.00 |  3454080 B | 
| fennecs           |    856,106 ns |     2.17 |  6815576 B | 
| TinyEcs           |    955,280 ns |     2.42 |  6119312 B | 
| Flecs.NET         |  1,341,023 ns |     3.39 |      736 B | 
| Leopotam.EcsLite  |  1,954,243 ns |     4.95 |  7322344 B | 
| Arch              |  2,116,586 ns |     5.37 |  3255040 B | 
| DefaultEcs        |  6,606,963 ns |    16.72 | 11592440 B | 
| Scellecs.Morpeh   | 42,806,285 ns |   108.53 | 42293688 B | 


### Create 100.000 entities with 3 components

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |    468,328 ns |     1.00 |  4506960 B | 
| fennecs           |    937,038 ns |     1.84 |  7866864 B | 
| TinyEcs           |    986,724 ns |     1.93 |  6942912 B | 
| Flecs.NET         |  1,472,139 ns |     2.91 |      736 B | 
| Leopotam.EcsLite  |  3,504,630 ns |     6.87 | 11517616 B | 
| DefaultEcs        |  5,709,662 ns |    11.47 | 19984552 B | 
| Arch              | 10,641,060 ns |    20.86 |  4042736 B | 
| Scellecs.Morpeh   | 29,669,684 ns |    58.26 | 49285544 B | 


### Create world

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         72 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS |        236 ns |     1.00 |     3992 B | 
| Leopotam.EcsLite  |      1,445 ns |     6.10 |    58944 B | 
| Arch              |      3,391 ns |    14.32 |    37040 B | 
| Scellecs.Morpeh   |      4,311 ns |    18.20 |     5056 B | 
| fennecs           |     15,311 ns |    64.63 |   169796 B | 
| TinyEcs           |     51,827 ns |   218.77 |  1312184 B | 
| Flecs.NET         |    994,502 ns | 4,198.49 |     1009 B | 


### Delete 100.000 entities with 5 components

**Note:**  
The high amount of allocations is an indicator that buffers used to store components are replaced by smaller buffers over time.  
Without this behavior the component buffers allocated by the ECS would never shrink.  
In case of Flecs.NET components are store in native heap which is not monitored by BenchmarkDotNet.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |  1,609,060 ns |     1.00 |  3122896 B | 
| Flecs.NET         |  1,989,204 ns |     1.24 |      736 B | 
| Arch              |  2,695,781 ns |     1.68 |     3088 B | 
| DefaultEcs        |  3,706,715 ns |     2.34 |  3200736 B | 
| Leopotam.EcsLite  |  4,666,441 ns |     2.90 |  6268768 B | 
| fennecs           |  5,698,660 ns |     3.54 |  4366912 B | 
| TinyEcs           |  8,313,336 ns |     5.17 |     1480 B | 
| Scellecs.Morpeh   |  8,696,239 ns |     5.42 |  1398360 B | 


### Get & Set 1 component on 100 entities

**Note:** Sparse Set based ECS projects are in lead because of viewer array lookups.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Leopotam.EcsLite  |         65 ns |     0.43 |          - | 
| DefaultEcs        |        111 ns |     0.74 |          - | 
| Friflo.Engine.ECS |        151 ns |     1.00 |          - | 
| Arch              |        288 ns |     1.91 |          - | 
| Scellecs.Morpeh   |        325 ns |     2.15 |          - | 
| Flecs.NET         |        582 ns |     3.84 |          - | 
| TinyEcs           |        717 ns |     4.74 |          - | 
| fennecs           |      2,354 ns |    15.55 |          - | 


### Query 100 entities with 1 component

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| DefaultEcs        |         45 ns |     0.93 |          - | 
| Friflo.Engine.ECS |         48 ns |     1.00 |          - | 
| TinyEcs           |         66 ns |     1.37 |          - | 
| Leopotam.EcsLite  |         76 ns |     1.58 |          - | 
| Arch              |        120 ns |     2.49 |          - | 
| Flecs.NET         |        143 ns |     2.96 |          - | 
| fennecs           |        176 ns |     3.64 |       40 B | 
| Scellecs.Morpeh   |        313 ns |     6.47 |          - | 

⁽¹⁾ Queries on components with reference type fields (e.g. string) require less performant query iteration.  
This specific case is not benchmarked.

### Query 100 entities with 5 components

**Note:** Archetype based ECS projects are in lead if results set is big - 100.000 or more.  
Returned components are sequentially stored in memory providing a high cache hit rate.

| ECS               | Mean          | Ratio    |   Allocated | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |        112 ns |     1.00 |          - | 
| TinyEcs           |        118 ns |     1.06 |          - | 
| Arch              |        198 ns |     1.77 |          - | 
| Flecs.NET         |        200 ns |     1.79 |          - | 
| DefaultEcs        |        271 ns |     2.42 |          - | 
| Leopotam.EcsLite  |        336 ns |     3.00 |          - | 
| fennecs           |        405 ns |     3.62 |       40 B | 
| Scellecs.Morpeh   |        790 ns |     7.05 |          - | 

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
| Friflo.Engine.ECS | 1             |     5,428 ns |     1.00 |          - | 
| Flecs.NET         | 1             |    10,567 ns |     1.95 |          - | 
| TinyEcs           | 1             |    15,696 ns |     2.89 |          - | 
| Arch              | 1             |    72,352 ns |    13.33 |    36800 B | 
| fennecs           | 1             |    94,680 ns |    17.44 |   180000 B | 
 

### Add & Remove 100 link relations on 100 entities

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Flecs.NET         | 100           |   967,353 ns |     0.84 |        1 B | 
| Friflo.Engine.ECS | 100           | 1,156,866 ns |     1.00 |        1 B | 
| TinyEcs           | 100           | 3,496,924 ns |     3.02 |        4 B | 
| Arch              | 100           | 4,297,847 ns |     3.72 |  2180006 B | 
| fennecs           | 100           |70,893,303 ns |    61.28 | 93124905 B | 

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
| Friflo.Engine.ECS | 1             |     3,385 ns |     1.00 |          - | 
| Flecs.NET         | 1             |    12,279 ns |     3.63 |          - | 
| TinyEcs           | 1             |    23,528 ns |     6.95 |          - | 
| Arch              | 1             |    49,004 ns |    14.47 |    36800 B | 
| fennecs           | 1             |    95,627 ns |    28.25 |   180000 B | 


### Add & Remove 10 relations on 100 entities

Each entity has 5 common components.

| ECS               | RelationCount | Mean         | Ratio    | Allocated   | 
|------------------ |-------------- |-------------:|---------:|------------:|
| Friflo.Engine.ECS | 10            |    45,817 ns |     1.00 |          - | 
| Flecs.NET         | 10            |   158,533 ns |     3.46 |          - | 
| Arch              | 10            |   200,083 ns |     4.37 |   240800 B | 
| TinyEcs           | 10            |   285,382 ns |     6.23 |        1 B | 
| fennecs           | 10            | 1,548,092 ns |    33.80 |  2528801 B | 


### Add & Remove 10 child entities on 100 parent entities

Child / parent entity relationships are used to build a hierarchy / tree of entities.  
It is, among other things, a use case for scene trees, entity parenting or character rig skeletons.

| ECS               |  Mean         | Ratio    | Allocated   | 
|------------------ |--------------:|---------:|------------:|
| Friflo.Engine.ECS |     37,385 ns |        ? |          - | 
| Flecs.NET         |     94,565 ns |        ? |          - | 
| TinyEcs           |    188,211 ns |        ? |          - | 
| Arch              |    430,421 ns |        ? |   232801 B | 
| fennecs           |    942,540 ns |        ? |  1800001 B | 

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
| Scellecs.Morpeh   |  5,121 ns |     0.60 |          - | 
| Friflo.Engine.ECS |  8,490 ns |     1.00 |          - | 
| TinyEcs           | 12,959 ns |     1.53 |     4800 B | 
| Flecs.NET         | 14,399 ns |     1.70 |          - | 
| DefaultEcs        | 16,476 ns |     1.94 |          - | 
| Arch              | 48,222 ns |     5.68 |     4800 B | 

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
| DefaultEcs        |  2,548 ns |     0.37 |          - | 
| TinyEcs           |  4,414 ns |     0.64 |          - | 
| Friflo.Engine.ECS |  6,935 ns |     1.00 |          - | 
| Flecs.NET         | 11,421 ns |     1.65 |          - | 

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
| Friflo.Engine.ECS |      4,760 ns |     1.00 |          - | 


### Search range of component fields in 1.000.000 entities

Execute 1000 range queries with different [min, max] in a data set of 1.000.000 entities.  
Each result has 100 matches.

| ECS               | Mean          | Ratio    | Allocated   | 
|------------------ | -------------:| --------:| -----------:|
| Friflo.Engine.ECS |  1,472,963 ns |     1.00 |   560001 B | 

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

