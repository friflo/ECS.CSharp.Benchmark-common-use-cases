```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=ShortRun  LaunchCount=1  
WarmupCount=3  

```
| Namespace         | Type                             | Mean         | Ratio    | Allocated | 
|------------------ |--------------------------------- |-------------:|---------:|----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |    10,963 ns |     0.22 |         - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |    14,415 ns |     0.29 |         - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |    24,150 ns |     0.49 |         - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |    28,804 ns |     0.59 |         - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |    48,965 ns |     1.00 |         - | 
| Arch              | AddRemoveComponentsT1_Arch       |    86,276 ns |     1.76 |  120000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |    87,688 ns |     1.79 |   64000 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |   391,123 ns |     7.99 |  864000 B | 
|                   |                                  |              |          |           | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |    52,533 ns |     0.75 |         - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |    69,852 ns |     1.00 |         - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |    73,653 ns |     1.05 |         - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |    83,695 ns |     1.20 |         - | 
| Arch              | AddRemoveComponentsT5_Arch       |   228,779 ns |     3.28 |   88000 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |   293,809 ns |     4.21 |         - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |   713,651 ns |    10.22 |  640001 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    | 3,056,342 ns |    43.76 | 6208003 B | 
|                   |                                  |              |          |           | 
| Leopotam.EcsLite  | CreateEntity_Leopotam            |         2 ns |     0.39 |      21 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo              |         7 ns |     1.00 |       5 B | 
| DefaultEcs        | CreateEntity_DefaultEcs          |        12 ns |     1.73 |      66 B | 
| Flecs.NET         | CreateEntity_FlecsNet            |        20 ns |     2.82 |       1 B | 
| Arch              | CreateEntity_Arch                |        25 ns |     3.36 |      36 B | 
| fennecs           | CreateEntity_Fennecs             |        27 ns |     3.67 |     214 B | 
| TinyEcs           | CreateEntity_TinyEcs             |        41 ns |     6.48 |       1 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh              |        80 ns |    10.73 |     376 B | 
|                   |                                  |              |          |           | 
| DefaultEcs        | CreateWorld_DefaultEcs           |        72 ns |     0.34 |     336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |       215 ns |     1.00 |    3576 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |     1,462 ns |     6.79 |   58944 B | 
| Arch              | CreateWorld_Arch                 |     3,378 ns |    15.68 |   37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |     4,294 ns |    19.93 |    5056 B | 
| fennecs           | CreateWorld_Fennecs              |    21,371 ns |    99.18 |  169820 B | 
| TinyEcs           | CreateWorld_TinyEcs              |    35,929 ns |   166.74 | 1087272 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |   926,724 ns | 4,300.78 |    2381 B | 
|                   |                                  |              |          |           | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |         3 ns |     0.25 |       5 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |        11 ns |     0.77 |      33 B | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |        15 ns |     1.00 |       1 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |        17 ns |     1.20 |       1 B | 
| Arch              | DeleteEntity_Arch                |        18 ns |     1.22 |      15 B | 
| fennecs           | DeleteEntity_Fennecs             |        19 ns |     1.32 |      25 B | 
| TinyEcs           | DeleteEntity_TinyEcs             |        55 ns |     3.72 |       1 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |       111 ns |     8.07 |      46 B | 
|                   |                                  |              |          |           | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |       668 ns |     0.42 |         - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |     1,099 ns |     0.69 |         - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |     1,590 ns |     1.00 |         - | 
| Arch              | GetSetComponentsT1_Arch          |     3,263 ns |     2.05 |         - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |     3,943 ns |     2.48 |         - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |     9,545 ns |     6.00 |         - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |    10,342 ns |     6.50 |         - | 
| fennecs           | GetSetComponentsT1_Fennecs       |    24,902 ns |    15.66 |         - | 
|                   |                                  |              |          |           | 
| TinyEcs           | QueryT1_TinyEcs                  |       364 ns |     0.75 |         - | 
| DefaultEcs        | QueryT1_Default                  |       484 ns |     1.00 |         - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |       487 ns |     1.00 |         - | 
| Flecs.NET         | QueryT1_FlecsNet                 |       574 ns |     1.18 |         - | 
| Arch              | QueryT1_Arch                     |       584 ns |     1.20 |         - | 
| fennecs           | QueryT1_Fennecs                  |       616 ns |     1.27 |      40 B | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |       778 ns |     1.60 |         - | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |     3,973 ns |     8.16 |         - | 
|                   |                                  |              |          |           | 
| TinyEcs           | QueryT5_TinyEcs                  |       851 ns |     0.92 |         - | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |       927 ns |     1.00 |         - | 
| Arch              | QueryT5_Arch                     |     1,190 ns |     1.28 |         - | 
| fennecs           | QueryT5_Fennecs                  |     1,360 ns |     1.47 |      40 B | 
| Flecs.NET         | QueryT5_FlecsNet                 |     1,998 ns |     2.15 |         - | 
| DefaultEcs        | QueryT5_DefaultEcs               |     2,643 ns |     2.85 |         - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |     3,287 ns |     3.54 |         - | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |     9,318 ns |    10.04 |         - | 
