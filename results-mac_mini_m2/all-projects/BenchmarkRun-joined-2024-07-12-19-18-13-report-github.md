```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-UNPDOV : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  

```
| Namespace         | Type                             | Mean             | Ratio    | Allocated   | 
|------------------ |--------------------------------- |-----------------:|---------:|------------:|-
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |        982.98 ns |     0.18 |           - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |      1,468.46 ns |     0.26 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |      1,836.68 ns |     0.33 |           - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |      2,929.03 ns |     0.53 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |      5,565.99 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT1_Arch       |      8,408.05 ns |     1.51 |     12000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |      8,880.57 ns |     1.60 |      6400 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |     38,943.15 ns |     7.00 |     86400 B | 
|                   |                                  |                  |          |             | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |      5,150.32 ns |     0.67 |           - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |      7,227.90 ns |     0.94 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |      7,653.10 ns |     1.00 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |      7,673.76 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT5_Arch       |     23,324.33 ns |     3.05 |      8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |     29,655.18 ns |     3.87 |           - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |     72,474.28 ns |     9.47 |     64000 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    |    304,670.49 ns |    39.81 |    620800 B | 
|                   |                                  |                  |          |             | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo            |    559,041.45 ns |     1.00 |       736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam          |  1,977,159.92 ns |     3.47 |   7316032 B | 
| Arch              | CreateEntityT1_Arch              |  2,747,543.51 ns |     5.73 |      3088 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs        |  3,117,007.98 ns |     5.56 |  11596552 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet          |  3,672,273.19 ns |     6.47 |      1152 B | 
| TinyEcs           | CreateEntityT1_TinyEcs           |  5,214,321.07 ns |     9.21 |   8020784 B | 
| fennecs           | CreateEntityT1_Fennecs           | 26,732,532.85 ns |    47.45 |  58844200 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh            | 43,161,848.43 ns |    76.25 |  42293152 B | 
|                   |                                  |                  |          |             | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo            |  1,113,676.17 ns |     1.00 |       736 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam          |  3,558,731.79 ns |     3.21 |  11498680 B | 
| Arch              | CreateEntityT3_Arch              |  5,358,092.58 ns |     4.83 |      3088 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs        |  5,833,096.96 ns |     5.24 |  19984544 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet          | 12,814,504.30 ns |    11.52 |      1984 B | 
| TinyEcs           | CreateEntityT3_TinyEcs           | 20,847,062.14 ns |    18.79 |  21824112 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh            | 30,036,222.86 ns |    27.07 |  49284080 B | 
| fennecs           | CreateEntityT3_Fennecs           | 89,222,205.64 ns |    80.41 | 196147968 B | 
|                   |                                  |                  |          |             | 
| DefaultEcs        | CreateWorld_DefaultEcs           |         72.80 ns |     0.34 |       336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |        216.52 ns |     1.00 |      3576 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |      1,463.21 ns |     6.76 |     58944 B | 
| Arch              | CreateWorld_Arch                 |      3,364.09 ns |    15.54 |     37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |      4,307.27 ns |    19.89 |      5056 B | 
| fennecs           | CreateWorld_Fennecs              |     15,134.13 ns |    69.91 |    169796 B | 
| TinyEcs           | CreateWorld_TinyEcs              |     35,831.86 ns |   165.51 |   1087272 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |    984,064.24 ns | 4,545.19 |      2394 B | 
|                   |                                  |                  |          |             | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |  1,629,512.07 ns |     1.00 |   3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |  1,829,085.73 ns |     1.12 |       736 B | 
| Arch              | DeleteEntity_Arch                |  2,700,191.83 ns |     1.66 |      3088 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |  3,728,846.21 ns |     2.27 |   3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |  4,763,063.60 ns |     2.92 |   6268768 B | 
| fennecs           | DeleteEntity_Fennecs             |  5,772,987.54 ns |     3.54 |   4366912 B | 
| TinyEcs           | DeleteEntity_TinyEcs             |  8,001,202.64 ns |     4.91 |      1144 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |  8,471,780.08 ns |     5.26 |   1398360 B | 
|                   |                                  |                  |          |             | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |         65.09 ns |     0.43 |           - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |        111.59 ns |     0.74 |           - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |        151.45 ns |     1.00 |           - | 
| Arch              | GetSetComponentsT1_Arch          |        310.61 ns |     2.05 |           - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |        326.80 ns |     2.16 |           - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |        989.18 ns |     6.53 |           - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |      1,041.81 ns |     6.88 |           - | 
| fennecs           | GetSetComponentsT1_Fennecs       |      2,342.13 ns |    15.46 |           - | 
|                   |                                  |                  |          |             | 
| DefaultEcs        | QueryT1_Default                  |         44.88 ns |     0.98 |           - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |         45.64 ns |     1.00 |           - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |         76.62 ns |     1.68 |           - | 
| TinyEcs           | QueryT1_TinyEcs                  |         90.27 ns |     1.98 |           - | 
| Flecs.NET         | QueryT1_FlecsNet                 |        112.33 ns |     2.46 |           - | 
| Arch              | QueryT1_Arch                     |        121.34 ns |     2.66 |           - | 
| fennecs           | QueryT1_Fennecs                  |        166.68 ns |     3.65 |        40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |        314.89 ns |     6.90 |           - | 
|                   |                                  |                  |          |             | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |        111.64 ns |     1.00 |           - | 
| TinyEcs           | QueryT5_TinyEcs                  |        148.15 ns |     1.33 |           - | 
| Arch              | QueryT5_Arch                     |        197.83 ns |     1.77 |           - | 
| Flecs.NET         | QueryT5_FlecsNet                 |        248.97 ns |     2.23 |           - | 
| DefaultEcs        | QueryT5_DefaultEcs               |        271.88 ns |     2.44 |           - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |        339.91 ns |     3.04 |           - | 
| fennecs           | QueryT5_Fennecs                  |        403.75 ns |     3.62 |        40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |        784.32 ns |     7.03 |           - | 
