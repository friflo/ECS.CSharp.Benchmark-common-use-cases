```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-WEGLLU : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  

```
| Namespace         | Type                             | Mean             | Ratio    | Allocated  | 
|------------------ |--------------------------------- |-----------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |        985.98 ns |     0.18 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |      1,472.27 ns |     0.26 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |      1,839.31 ns |     0.33 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |      2,932.91 ns |     0.52 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |      5,604.25 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT1_Arch       |      8,407.88 ns |     1.50 |    12000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |      8,860.32 ns |     1.58 |     6400 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |     38,806.97 ns |     6.92 |    86400 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |      5,184.81 ns |     0.67 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |      7,318.71 ns |     0.95 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |      7,661.87 ns |     0.99 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |      7,729.32 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT5_Arch       |     22,600.32 ns |     2.92 |     8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |     31,107.70 ns |     4.02 |          - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |     71,567.63 ns |     9.26 |    64000 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    |    306,096.80 ns |    39.60 |   620800 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo            |    392,928.79 ns |     1.00 |  3449408 B | 
| fennecs           | CreateEntityT1_Fennecs           |    865,500.14 ns |     2.20 |  6815576 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam          |  2,022,041.39 ns |     5.17 |  7316032 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs        |  3,086,095.65 ns |     7.93 | 11596552 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet          |  3,635,893.77 ns |     9.28 |     1152 B | 
| TinyEcs           | CreateEntityT1_TinyEcs           |  5,005,610.60 ns |    12.75 |  8020784 B | 
| Arch              | CreateEntityT1_Arch              |  5,249,985.73 ns |    13.66 |     3088 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh            | 43,054,258.57 ns |   109.60 | 42293152 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo            |    441,317.00 ns |     1.00 |  4498032 B | 
| fennecs           | CreateEntityT3_Fennecs           |    936,082.77 ns |     2.12 |  7866864 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam          |  3,552,742.04 ns |     8.05 | 11498680 B | 
| Arch              | CreateEntityT3_Arch              |  4,457,608.03 ns |    12.82 |     3088 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs        |  5,819,816.68 ns |    13.43 | 19984656 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet          | 12,676,827.33 ns |    28.68 |     1984 B | 
| TinyEcs           | CreateEntityT3_TinyEcs           | 20,568,728.71 ns |    46.63 | 21824112 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh            | 29,992,288.21 ns |    67.99 | 49284080 B | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs           |         73.00 ns |     0.34 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |        216.05 ns |     1.00 |     3576 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |      1,461.03 ns |     6.76 |    58944 B | 
| Arch              | CreateWorld_Arch                 |      3,389.58 ns |    15.69 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |      4,305.43 ns |    19.93 |     5056 B | 
| fennecs           | CreateWorld_Fennecs              |     15,140.39 ns |    70.08 |   169796 B | 
| TinyEcs           | CreateWorld_TinyEcs              |     36,124.31 ns |   167.20 |  1087272 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |    954,424.79 ns | 4,417.69 |     2381 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |  1,624,681.07 ns |     1.00 |  3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |  1,833,584.81 ns |     1.13 |      736 B | 
| Arch              | DeleteEntity_Arch                |  2,643,530.92 ns |     1.63 |     3088 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |  3,644,236.95 ns |     2.25 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |  4,627,492.41 ns |     2.84 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs             |  5,769,115.46 ns |     3.55 |  4366912 B | 
| TinyEcs           | DeleteEntity_TinyEcs             |  7,974,388.75 ns |     4.91 |     1144 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |  8,642,839.81 ns |     5.25 |  1398360 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |         65.15 ns |     0.43 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |        111.78 ns |     0.74 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |        151.42 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch          |        314.31 ns |     2.08 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |        327.07 ns |     2.16 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |      1,001.32 ns |     6.61 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |      1,038.66 ns |     6.86 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs       |      2,346.34 ns |    15.50 |          - | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | QueryT1_Default                  |         45.10 ns |     0.95 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |         47.68 ns |     1.00 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |         76.66 ns |     1.61 |          - | 
| TinyEcs           | QueryT1_TinyEcs                  |         90.83 ns |     1.91 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                 |        113.66 ns |     2.38 |          - | 
| Arch              | QueryT1_Arch                     |        117.92 ns |     2.47 |          - | 
| fennecs           | QueryT1_Fennecs                  |        166.36 ns |     3.49 |       40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |        312.29 ns |     6.55 |          - | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |        110.23 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                  |        145.40 ns |     1.32 |          - | 
| Arch              | QueryT5_Arch                     |        199.98 ns |     1.81 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                 |        250.39 ns |     2.27 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs               |        271.00 ns |     2.46 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |        345.75 ns |     3.14 |          - | 
| fennecs           | QueryT5_Fennecs                  |        404.33 ns |     3.67 |       40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |        790.32 ns |     7.17 |          - | 
