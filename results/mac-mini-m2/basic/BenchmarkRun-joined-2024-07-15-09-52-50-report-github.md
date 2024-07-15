```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-KIZANQ : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  

```
| Namespace         | Type                             | Mean              | Ratio    | Allocated   | 
|------------------ |--------------------------------- |------------------:|---------:|------------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |         977.24 ns |     0.17 |           - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |       1,435.58 ns |     0.25 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |       1,829.56 ns |     0.32 |           - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |       2,924.57 ns |     0.51 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |       5,706.08 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT1_Arch       |       8,671.81 ns |     1.52 |     12000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |      11,945.18 ns |     2.09 |      6400 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |      38,592.21 ns |     6.76 |     86400 B | 
|                   |                                  |                   |          |             | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |       5,133.19 ns |     0.66 |           - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |       7,246.23 ns |     0.93 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |       7,605.21 ns |     0.98 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |       7,780.88 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT5_Arch       |      22,366.44 ns |     2.87 |      8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |      31,669.00 ns |     4.07 |           - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |      86,149.40 ns |    11.07 |     64000 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    |     305,012.51 ns |    39.20 |    620800 B | 
|                   |                                  |                   |          |             | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo            |     398,582.92 ns |     1.00 |   3449408 B | 
| fennecs           | CreateEntityT1_Fennecs           |     864,422.64 ns |     2.15 |   6815576 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet          |   1,323,135.13 ns |     3.32 |       736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam          |   1,966,467.54 ns |     4.88 |   7316032 B | 
| Arch              | CreateEntityT1_Arch              |   5,260,709.62 ns |    13.21 |      3088 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs        |   6,601,481.15 ns |    16.38 |  11592448 B | 
| TinyEcs           | CreateEntityT1_TinyEcs           |   6,755,046.87 ns |    16.78 |  10118352 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh            |  42,849,157.43 ns |   106.38 |  42293152 B | 
|                   |                                  |                   |          |             | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo            |     453,287.83 ns |     1.00 |   4498032 B | 
| fennecs           | CreateEntityT3_Fennecs           |     934,082.92 ns |     2.06 |   7866864 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet          |   1,462,341.33 ns |     3.22 |       736 B | 
| Arch              | CreateEntityT3_Arch              |   1,855,739.64 ns |     4.08 |      3088 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam          |   2,624,818.23 ns |     5.89 |  11498680 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs        |   5,790,311.50 ns |    12.99 |  19984528 B | 
| TinyEcs           | CreateEntityT3_TinyEcs           |  23,360,839.21 ns |    51.56 |  23921880 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh            |  29,691,392.57 ns |    65.51 |  49284080 B | 
|                   |                                  |                   |          |             | 
| DefaultEcs        | CreateWorld_DefaultEcs           |          72.98 ns |     0.34 |       336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |         216.15 ns |     1.00 |      3584 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |       1,463.23 ns |     6.77 |     58944 B | 
| Arch              | CreateWorld_Arch                 |       3,392.92 ns |    15.70 |     37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |       4,296.71 ns |    19.88 |      5056 B | 
| fennecs           | CreateWorld_Fennecs              |      15,120.40 ns |    69.95 |    169796 B | 
| TinyEcs           | CreateWorld_TinyEcs              |      33,251.06 ns |   153.85 |    889424 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |   1,000,598.06 ns | 4,629.00 |      1009 B | 
|                   |                                  |                   |          |             | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |   1,551,068.14 ns |     1.00 |   3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |   1,993,240.64 ns |     1.29 |       736 B | 
| Arch              | DeleteEntity_Arch                |   2,635,788.23 ns |     1.70 |      3088 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |   3,734,260.25 ns |     2.42 |   3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |   4,553,305.07 ns |     2.94 |   6268768 B | 
| fennecs           | DeleteEntity_Fennecs             |   5,827,321.00 ns |     3.76 |   4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |   8,721,128.64 ns |     5.41 |   1398360 B | 
| TinyEcs           | DeleteEntity_TinyEcs             | 286,001,355.67 ns |   184.49 | 491139424 B | 
|                   |                                  |                   |          |             | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |          65.19 ns |     0.43 |           - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |         111.68 ns |     0.74 |           - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |         151.50 ns |     1.00 |           - | 
| Arch              | GetSetComponentsT1_Arch          |         279.05 ns |     1.84 |           - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |         329.45 ns |     2.17 |           - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |         581.88 ns |     3.84 |           - | 
| fennecs           | GetSetComponentsT1_Fennecs       |       2,420.50 ns |    15.98 |           - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |       2,481.20 ns |    16.38 |           - | 
|                   |                                  |                   |          |             | 
| DefaultEcs        | QueryT1_Default                  |          45.09 ns |     0.99 |           - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |          45.54 ns |     1.00 |           - | 
| TinyEcs           | QueryT1_TinyEcs                  |          65.43 ns |     1.44 |           - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |          76.65 ns |     1.68 |           - | 
| Arch              | QueryT1_Arch                     |         120.17 ns |     2.64 |           - | 
| Flecs.NET         | QueryT1_FlecsNet                 |         142.58 ns |     3.13 |           - | 
| fennecs           | QueryT1_Fennecs                  |         170.73 ns |     3.75 |        40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |         313.08 ns |     6.87 |           - | 
|                   |                                  |                   |          |             | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |         111.22 ns |     1.00 |           - | 
| TinyEcs           | QueryT5_TinyEcs                  |         115.09 ns |     1.03 |           - | 
| Arch              | QueryT5_Arch                     |         196.89 ns |     1.77 |           - | 
| Flecs.NET         | QueryT5_FlecsNet                 |         198.76 ns |     1.79 |           - | 
| DefaultEcs        | QueryT5_DefaultEcs               |         271.90 ns |     2.45 |           - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |         345.53 ns |     3.11 |           - | 
| fennecs           | QueryT5_Fennecs                  |         407.03 ns |     3.66 |        40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |         783.07 ns |     7.04 |           - | 
