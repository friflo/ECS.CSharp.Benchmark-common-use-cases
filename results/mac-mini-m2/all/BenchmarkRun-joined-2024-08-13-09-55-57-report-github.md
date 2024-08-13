```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.6.1 (23G93) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-VLAROU : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-RJMUXD : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Namespace         | Type                              | Entities | Components | Relations | Mean              | Ratio    | Allocated  | 
|------------------ |---------------------------------- |--------- |----------- |---------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 1          | ?         |        980.127 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 1          | ?         |      1,450.440 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 1          | ?         |      1,681.389 ns |     0.29 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 1          | ?         |      3,767.635 ns |     0.65 |          - | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 1          | ?         |      3,953.487 ns |     0.68 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 1          | ?         |      4,143.369 ns |     0.72 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 1          | ?         |      5,789.523 ns |     1.00 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 1          | ?         |     20,178.103 ns |     3.49 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 1          | ?         |     39,154.557 ns |     6.76 |    86400 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 5          | ?         |      4,993.250 ns |     0.64 |          - | 
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 5          | ?         |      5,120.925 ns |     0.66 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 5          | ?         |      7,194.957 ns |     0.93 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 5          | ?         |      7,770.220 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 5          | ?         |     21,541.424 ns |     2.77 |     8800 B | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 5          | ?         |     29,866.364 ns |     3.84 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 5          | ?         |     35,166.573 ns |     4.53 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 5          | ?         |     55,405.953 ns |     7.13 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 5          | ?         |    307,471.643 ns |    39.57 |   620800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 1         |      5,913.034 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 1         |     10,486.248 ns |     1.77 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 1         |     15,721.780 ns |     2.66 |          - | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 1         |     62,031.663 ns |    10.49 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 1         |     93,813.942 ns |    15.87 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 100       |    964,524.280 ns |     0.77 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 100       |  1,247,139.215 ns |     1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 100       |  3,921,221.319 ns |     3.14 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 100       |  4,689,757.182 ns |     3.76 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 100       | 71,224,014.723 ns |    57.11 | 93124905 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 1         |      3,763.245 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 1         |     12,238.146 ns |     3.25 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 1         |     23,595.227 ns |     6.27 |          - | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 1         |     41,338.115 ns |    10.98 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 1         |     96,236.332 ns |    25.57 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 100       |     46,737.992 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 100       |    158,719.567 ns |     3.40 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 100       |    283,079.258 ns |     6.06 |        1 B | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 100       |  1,568,619.999 ns |    33.56 |  2180001 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 100       |  1,605,573.105 ns |    34.35 |  2562401 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo     | 100      | ?          | ?         |     25,691.893 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet   | 100      | ?          | ?         |     94,632.792 ns |     3.68 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs    | 100      | ?          | ?         |    189,846.902 ns |     7.39 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch       | 100      | ?          | ?         |    389,411.057 ns |    15.16 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs    | 100      | ?          | ?         |    945,941.845 ns |    36.82 |  1800001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemove_Morpeh     | 100      | ?          | ?         |      5,053.403 ns |     0.59 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemove_Friflo     | 100      | ?          | ?         |      8,613.365 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemove_TinyEcs    | 100      | ?          | ?         |     12,786.534 ns |     1.48 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemove_FlecsNet   | 100      | ?          | ?         |     14,370.833 ns |     1.67 |          - | 
| DefaultEcs        | CommandBufferAddRemove_DefaultEcs | 100      | ?          | ?         |     16,532.109 ns |     1.92 |          - | 
| Myriad            | CommandBufferAddRemove_Myriad     | 100      | ?          | ?         |     28,347.129 ns |     3.29 |       96 B | 
| Arch              | CommandBufferAddRemove_Arch       | 100      | ?          | ?         |     46,530.839 ns |     5.40 |    12800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | ComponentEvents_DefaultEcs        | 100      | ?          | ?         |      2,612.909 ns |     0.34 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs           | 100      | ?          | ?         |      4,431.076 ns |     0.58 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo            | 100      | ?          | ?         |      7,659.422 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet          | 100      | ?          | ?         |     11,219.939 ns |     1.47 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 1          | ?         |      1,029.850 ns |     1.00 |     7856 B | 
| Arch              | CreateBulk_Arch                   | 100      | 1          | ?         |     10,264.270 ns |     9.98 |    70736 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 1          | ?         |     17,996.786 ns |    17.50 |   210712 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 3          | ?         |      1,609.096 ns |     1.00 |    12112 B | 
| Arch              | CreateBulk_Arch                   | 100      | 3          | ?         |      7,389.571 ns |     4.61 |    54408 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 3          | ?         |     25,397.154 ns |    15.84 |   214448 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 1          | ?         |      1,352.000 ns |     0.30 |     7048 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 1          | ?         |      3,698.119 ns |     0.82 |    12960 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 1          | ?         |      4,545.185 ns |     1.00 |    11600 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 1          | ?         |      5,416.333 ns |     1.19 |    86264 B | 
| Arch              | CreateEntity_Arch                 | 100      | 1          | ?         |      6,071.800 ns |     1.34 |    36728 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 1          | ?         |      8,951.699 ns |     1.97 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 1          | ?         |     11,288.571 ns |     2.49 |    18984 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 1          | ?         |     13,565.143 ns |     2.99 |    42896 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 1          | ?         |     36,814.528 ns |     8.11 |   252376 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 3          | ?         |      3,216.333 ns |     0.84 |    19672 B | 
| Arch              | CreateEntity_Arch                 | 100      | 3          | ?         |      3,589.579 ns |     0.94 |    20344 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 3          | ?         |      3,828.273 ns |     1.00 |    15856 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 3          | ?         |      7,782.429 ns |     2.04 |    23368 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 3          | ?         |      8,840.263 ns |     2.31 |   121896 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 3          | ?         |     16,732.429 ns |     4.38 |    54400 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 3          | ?         |     19,062.174 ns |     4.99 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 3          | ?         |     20,742.448 ns |     5.43 |    27336 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 3          | ?         |    102,702.786 ns |    26.86 |   395856 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs            | ?        | ?          | ?         |         74.283 ns |     0.32 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                | ?        | ?          | ?         |        233.348 ns |     1.00 |     3952 B | 
| Myriad            | CreateWorld_Myriad                | ?        | ?          | ?         |        802.160 ns |     3.44 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam              | ?        | ?          | ?         |      1,456.316 ns |     6.24 |    58944 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                | ?        | ?          | ?         |      4,286.902 ns |    18.37 |     5056 B | 
| Arch              | CreateWorld_Arch                  | ?        | ?          | ?         |      6,044.834 ns |    25.90 |    69728 B | 
| fennecs           | CreateWorld_Fennecs               | ?        | ?          | ?         |     21,561.575 ns |    92.40 |   169364 B | 
| TinyEcs           | CreateWorld_TinyEcs               | ?        | ?          | ?         |     51,596.651 ns |   221.12 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet              | ?        | ?          | ?         |    994,220.442 ns | 4,260.69 |     1009 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo               | 100000   | 5          | ?         |  1,560,333.083 ns |     1.00 |      736 B | 
| Flecs.NET         | DeleteEntity_FlecsNet             | 100000   | 5          | ?         |  1,991,038.714 ns |     1.28 |      736 B | 
| Arch              | DeleteEntity_Arch                 | 100000   | 5          | ?         |  3,095,627.000 ns |     1.98 |     3088 B | 
| TinyEcs           | DeleteEntity_TinyEcs              | 100000   | 5          | ?         |  3,403,703.577 ns |     2.18 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs           | 100000   | 5          | ?         |  3,737,899.368 ns |     2.40 |  3200736 B | 
| Myriad            | DeleteEntity_Myriad               | 100000   | 5          | ?         |  4,673,305.867 ns |     3.00 |  8996128 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam             | 100000   | 5          | ?         |  4,726,736.933 ns |     3.03 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs              | 100000   | 5          | ?         |  5,675,881.214 ns |     3.64 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh               | 100000   | 5          | ?         |  8,468,637.034 ns |     5.43 |  1398360 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 1          | ?         |         65.621 ns |     0.33 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 1          | ?         |        115.523 ns |     0.57 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 1          | ?         |        141.102 ns |     0.70 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 1          | ?         |        201.002 ns |     1.00 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 1          | ?         |        262.220 ns |     1.30 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 1          | ?         |        345.102 ns |     1.72 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 1          | ?         |        584.002 ns |     2.91 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 1          | ?         |        725.832 ns |     3.61 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 1          | ?         |      2,384.445 ns |    11.86 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 5          | ?         |        308.520 ns |     0.77 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 5          | ?         |        401.953 ns |     1.00 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 5          | ?         |        456.103 ns |     1.13 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 5          | ?         |        614.973 ns |     1.53 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 5          | ?         |      1,287.856 ns |     3.20 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 5          | ?         |      1,707.832 ns |     4.25 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 5          | ?         |      2,691.745 ns |     6.70 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 5          | ?         |      4,049.358 ns |    10.08 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 5          | ?         |     14,351.015 ns |    35.71 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 1          | ?         |         44.446 ns |     0.87 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 1          | ?         |         50.912 ns |     1.00 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 1          | ?         |         66.873 ns |     1.31 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 1          | ?         |         68.918 ns |     1.35 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 1          | ?         |         77.321 ns |     1.52 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 1          | ?         |        139.694 ns |     2.74 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 1          | ?         |        198.312 ns |     3.90 |       88 B | 
| Arch              | QueryComponents_Arch              | 100      | 1          | ?         |        286.173 ns |     5.62 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 1          | ?         |        374.830 ns |     7.36 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 5          | ?         |         68.173 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 5          | ?         |         70.708 ns |     1.04 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 5          | ?         |        123.797 ns |     1.82 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 5          | ?         |        200.650 ns |     2.94 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 5          | ?         |        272.380 ns |     4.00 |          - | 
| Arch              | QueryComponents_Arch              | 100      | 5          | ?         |        307.350 ns |     4.51 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 5          | ?         |        341.536 ns |     5.01 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 5          | ?         |        436.836 ns |     6.41 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 5          | ?         |        783.239 ns |    11.49 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 1          | ?         |     46,960.906 ns |     0.96 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 1          | ?         |     48,839.386 ns |     1.00 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 1          | ?         |     48,923.425 ns |     1.00 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 1          | ?         |     49,009.978 ns |     1.00 |       88 B | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 1          | ?         |     49,072.479 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 1          | ?         |     50,425.767 ns |     1.03 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 1          | ?         |     77,982.912 ns |     1.59 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 1          | ?         |    210,985.385 ns |     4.31 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 1          | ?         |    847,819.905 ns |    17.33 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 5          | ?         |     47,986.177 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 5          | ?         |     56,851.105 ns |     1.18 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 5          | ?         |     77,593.589 ns |     1.62 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 5          | ?         |     87,873.878 ns |     1.83 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 5          | ?         |    108,411.310 ns |     2.26 |       88 B | 
| Arch              | QueryComponents_Arch              | 100000   | 5          | ?         |    229,966.619 ns |     4.79 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 5          | ?         |    317,963.864 ns |     6.63 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 5          | ?         |    352,539.376 ns |     7.35 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 5          | ?         |  2,038,169.515 ns |    42.47 |        3 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmented_Morpeh            | 32       | ?          | ?         |          4.575 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmented_Default           | 32       | ?          | ?         |         12.847 ns |     0.34 |          - | 
| Leopotam.EcsLite  | QueryFragmented_Leopotam          | 32       | ?          | ?         |         24.362 ns |     0.65 |          - | 
| Friflo.Engine.ECS | QueryFragmented_Friflo            | 32       | ?          | ?         |         37.709 ns |     1.00 |          - | 
| Myriad            | QueryFragmented_Myriad            | 32       | ?          | ?         |         93.390 ns |     2.48 |          - | 
| TinyEcs           | QueryFragmented_TinyEcs           | 32       | ?          | ?         |        130.482 ns |     3.46 |          - | 
| Arch              | QueryFragmented_Arch              | 32       | ?          | ?         |        228.183 ns |     6.05 |          - | 
| Flecs.NET         | QueryFragmented_FlecsNet          | 32       | ?          | ?         |        316.998 ns |     8.41 |          - | 
| fennecs           | QueryFragmented_Fennecs           | 32       | ?          | ?         |      1,532.115 ns |    40.63 |      120 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo       | 1000000  | ?          | ?         |      4,730.693 ns |     1.00 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                | 1000000  | ?          | ?         |  1,477,715.234 ns |     1.00 |   560001 B | 
