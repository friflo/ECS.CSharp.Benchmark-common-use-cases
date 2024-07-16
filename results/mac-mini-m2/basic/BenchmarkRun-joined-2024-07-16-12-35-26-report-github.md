```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-QCZYEK : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated   | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|------------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam      | ?             |         976.05 ns |     0.17 |           - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs    | ?             |       1,461.43 ns |     0.26 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh        | ?             |       1,834.47 ns |     0.33 |           - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet      | ?             |       2,931.70 ns |     0.52 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo        | ?             |       5,636.22 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT1_Arch          | ?             |       8,677.23 ns |     1.54 |     12000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs       | ?             |      12,071.95 ns |     2.14 |      6400 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs       | ?             |      38,996.78 ns |     6.92 |     86400 B | 
|                   |                                     |               |                   |          |             | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam      | ?             |       5,129.98 ns |     0.67 |           - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs    | ?             |       7,218.18 ns |     0.94 |           - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh        | ?             |       7,641.44 ns |     0.99 |           - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo        | ?             |       7,691.35 ns |     1.00 |           - | 
| Arch              | AddRemoveComponentsT5_Arch          | ?             |      21,984.32 ns |     2.86 |      8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet      | ?             |      30,191.62 ns |     3.93 |           - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs       | ?             |      85,659.15 ns |    11.13 |     64001 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs       | ?             |     326,645.54 ns |    42.47 |    620800 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 1             |       5,079.46 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 1             |      10,547.73 ns |     2.08 |           - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 1             |      29,066.88 ns |     5.72 |     22400 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 1             |      94,018.67 ns |    18.51 |    180000 B | 
|                   |                                     |               |                   |          |             | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 100           |     946,965.33 ns |     0.81 |         1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 100           |   1,174,364.42 ns |     1.00 |         1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 100           |   9,017,758.64 ns |     7.68 |  18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 100           |  71,485,885.42 ns |    60.87 |  93124892 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 1             |       3,083.93 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 1             |       4,894.79 ns |     1.59 |           - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 1             |      32,151.28 ns |    10.43 |     53600 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 1             |      40,777.41 ns |    13.22 |     86400 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 10            |      48,452.44 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 10            |     106,787.94 ns |     2.20 |           - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 10            |     445,950.23 ns |     9.20 |    694400 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 10            |     977,793.31 ns |    20.18 |   1704801 B | 
|                   |                                     |               |                   |          |             | 
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?             |       5,064.27 ns |     0.58 |           - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?             |       8,736.44 ns |     1.00 |           - | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?             |       9,844.70 ns |     1.13 |           - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?             |      16,674.18 ns |     1.91 |           - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?             |      29,329.31 ns |     3.36 |     20800 B | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?             |      48,425.98 ns |     5.54 |      4800 B | 
|                   |                                     |               |                   |          |             | 
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?             |       2,602.10 ns |     0.35 |           - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?             |       7,480.85 ns |     1.00 |           - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?             |      10,419.53 ns |     1.39 |           - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?             |      13,781.00 ns |     1.84 |      6400 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo               | ?             |     391,076.54 ns |     1.00 |   3449408 B | 
| fennecs           | CreateEntityT1_Fennecs              | ?             |     876,606.38 ns |     2.24 |   6815576 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet             | ?             |   1,303,024.27 ns |     3.32 |       736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam             | ?             |   1,976,172.36 ns |     5.05 |   7316032 B | 
| Arch              | CreateEntityT1_Arch                 | ?             |   5,230,890.48 ns |    13.48 |      3088 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs           | ?             |   6,565,510.31 ns |    16.79 |  11592432 B | 
| TinyEcs           | CreateEntityT1_TinyEcs              | ?             |   6,826,935.54 ns |    17.46 |  10118352 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh               | ?             |  42,953,791.36 ns |   109.89 |  42293184 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo               | ?             |     448,975.68 ns |     1.00 |   4498032 B | 
| fennecs           | CreateEntityT3_Fennecs              | ?             |     937,536.07 ns |     2.07 |   7866864 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet             | ?             |   1,464,115.65 ns |     3.24 |       736 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam             | ?             |   2,633,338.80 ns |     5.91 |  11498680 B | 
| Arch              | CreateEntityT3_Arch                 | ?             |   5,395,988.67 ns |    11.90 |      3088 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs           | ?             |   5,774,491.22 ns |    12.90 |  19984528 B | 
| TinyEcs           | CreateEntityT3_TinyEcs              | ?             |  23,657,636.42 ns |    52.30 |  23921880 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh               | ?             |  29,805,461.43 ns |    65.76 |  49284080 B | 
|                   |                                     |               |                   |          |             | 
| DefaultEcs        | CreateWorld_DefaultEcs              | ?             |          72.19 ns |     0.33 |       336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                  | ?             |         216.19 ns |     1.00 |      3592 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam                | ?             |       1,446.22 ns |     6.69 |     58944 B | 
| Arch              | CreateWorld_Arch                    | ?             |       3,380.72 ns |    15.64 |     37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                  | ?             |       4,286.78 ns |    19.83 |      5056 B | 
| fennecs           | CreateWorld_Fennecs                 | ?             |      15,301.15 ns |    70.79 |    169796 B | 
| TinyEcs           | CreateWorld_TinyEcs                 | ?             |      34,447.12 ns |   159.35 |    889424 B | 
| Flecs.NET         | CreateWorld_FlecsNet                | ?             |     979,837.08 ns | 4,532.77 |      1009 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | DeleteEntity_Friflo                 | ?             |   1,613,736.40 ns |     1.00 |   3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet               | ?             |   2,008,759.31 ns |     1.24 |       736 B | 
| Arch              | DeleteEntity_Arch                   | ?             |   2,684,300.93 ns |     1.66 |      3088 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs             | ?             |   3,686,282.21 ns |     2.29 |   3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam               | ?             |   4,793,088.47 ns |     2.97 |   6268768 B | 
| fennecs           | DeleteEntity_Fennecs                | ?             |   5,764,400.00 ns |     3.57 |   4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh                 | ?             |   8,046,867.87 ns |     4.99 |   1398360 B | 
| TinyEcs           | DeleteEntity_TinyEcs                | ?             | 286,738,797.46 ns |   177.68 | 491139416 B | 
|                   |                                     |               |                   |          |             | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam         | ?             |          65.23 ns |     0.42 |           - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs       | ?             |         111.37 ns |     0.72 |           - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo           | ?             |         154.72 ns |     1.00 |           - | 
| Arch              | GetSetComponentsT1_Arch             | ?             |         282.45 ns |     1.83 |           - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh           | ?             |         326.27 ns |     2.11 |           - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet         | ?             |         581.94 ns |     3.76 |           - | 
| fennecs           | GetSetComponentsT1_Fennecs          | ?             |       2,426.19 ns |    15.68 |           - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs          | ?             |       2,460.84 ns |    15.91 |           - | 
|                   |                                     |               |                   |          |             | 
| DefaultEcs        | QueryT1_Default                     | ?             |          44.84 ns |     0.95 |           - | 
| Friflo.Engine.ECS | QueryT1_Friflo                      | ?             |          47.15 ns |     1.00 |           - | 
| TinyEcs           | QueryT1_TinyEcs                     | ?             |          65.99 ns |     1.40 |           - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                    | ?             |          76.57 ns |     1.62 |           - | 
| Arch              | QueryT1_Arch                        | ?             |         119.62 ns |     2.54 |           - | 
| Flecs.NET         | QueryT1_FlecsNet                    | ?             |         142.83 ns |     3.03 |           - | 
| fennecs           | QueryT1_Fennecs                     | ?             |         166.38 ns |     3.53 |        40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                      | ?             |         314.91 ns |     6.68 |           - | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | QueryT5_Friflo                      | ?             |         111.93 ns |     1.00 |           - | 
| TinyEcs           | QueryT5_TinyEcs                     | ?             |         119.66 ns |     1.07 |           - | 
| Arch              | QueryT5_Arch                        | ?             |         197.16 ns |     1.76 |           - | 
| Flecs.NET         | QueryT5_FlecsNet                    | ?             |         207.37 ns |     1.85 |           - | 
| DefaultEcs        | QueryT5_DefaultEcs                  | ?             |         271.31 ns |     2.42 |           - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                    | ?             |         339.35 ns |     3.03 |           - | 
| fennecs           | QueryT5_Fennecs                     | ?             |         404.70 ns |     3.62 |        40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                      | ?             |         787.16 ns |     7.03 |           - | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | SearchComponentField_Friflo         | ?             |       4,875.02 ns |     1.00 |           - | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | SearchRange_Friflo                  | ?             |   1,343,502.49 ns |     1.00 |    560001 B | 
