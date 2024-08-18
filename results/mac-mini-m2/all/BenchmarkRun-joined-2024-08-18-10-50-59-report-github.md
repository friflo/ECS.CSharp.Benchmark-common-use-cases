```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.6.1 (23G93) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-OHSCMH : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-QRRXBS : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Namespace         | Type                              | Entities | Components | Relations | Mean              | Ratio    | Allocated  | 
|------------------ |---------------------------------- |--------- |----------- |---------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 1          | ?         |        984.182 ns |     0.65 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 1          | ?         |      1,430.328 ns |     0.94 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 1          | ?         |      1,522.157 ns |     1.00 |          - | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 1          | ?         |      1,670.838 ns |     1.10 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 1          | ?         |      3,758.020 ns |     2.47 |          - | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 1          | ?         |      3,980.633 ns |     2.62 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 1          | ?         |      4,888.522 ns |     3.21 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 1          | ?         |     19,843.476 ns |    13.04 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 1          | ?         |     38,827.655 ns |    25.51 |    86400 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 5          | ?         |      4,992.196 ns |     0.83 |          - | 
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 5          | ?         |      5,119.823 ns |     0.85 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 5          | ?         |      6,028.132 ns |     1.00 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 5          | ?         |      7,229.947 ns |     1.20 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 5          | ?         |     22,797.943 ns |     3.78 |     8800 B | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 5          | ?         |     29,402.747 ns |     4.88 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 5          | ?         |     37,091.453 ns |     6.15 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 5          | ?         |     56,172.148 ns |     9.32 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 5          | ?         |    306,175.532 ns |    50.79 |   620800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 1         |      5,899.660 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 1         |     10,400.941 ns |     1.76 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 1         |     15,892.503 ns |     2.69 |          - | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 1         |     61,389.477 ns |    10.41 |    46400 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 1         |     92,059.776 ns |    15.60 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 100       |    969,439.035 ns |     0.79 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 100       |  1,230,937.313 ns |     1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 100       |  4,049,228.826 ns |     3.29 |  3140006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 100       |  4,689,269.391 ns |     3.81 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 100       | 70,225,222.592 ns |    57.06 | 93124892 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 1         |      3,792.743 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 1         |     11,877.547 ns |     3.13 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 1         |     23,501.084 ns |     6.20 |          - | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 1         |     42,515.097 ns |    11.21 |    39200 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 1         |     96,717.580 ns |    25.50 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 100       |     46,187.591 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 100       |    157,669.159 ns |     3.41 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 100       |    283,791.475 ns |     6.14 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 100       |  1,537,050.991 ns |    33.28 |  2545601 B | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 100       |  1,740,195.438 ns |    37.68 |  3140001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo     | 100      | ?          | ?         |     25,690.723 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet   | 100      | ?          | ?         |     94,068.145 ns |     3.66 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs    | 100      | ?          | ?         |    190,207.632 ns |     7.40 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch       | 100      | ?          | ?         |    396,710.671 ns |    15.44 |   280801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs    | 100      | ?          | ?         |    941,986.065 ns |    36.67 |  1800001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemove_Morpeh     | 100      | ?          | ?         |      5,041.299 ns |     0.63 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemove_Friflo     | 100      | ?          | ?         |      7,960.826 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemove_TinyEcs    | 100      | ?          | ?         |     12,706.181 ns |     1.60 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemove_FlecsNet   | 100      | ?          | ?         |     14,349.087 ns |     1.80 |          - | 
| DefaultEcs        | CommandBufferAddRemove_DefaultEcs | 100      | ?          | ?         |     16,596.993 ns |     2.08 |          - | 
| Myriad            | CommandBufferAddRemove_Myriad     | 100      | ?          | ?         |     29,091.801 ns |     3.65 |       96 B | 
| Arch              | CommandBufferAddRemove_Arch       | 100      | ?          | ?         |     48,424.053 ns |     6.08 |    12800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | ComponentEvents_Friflo            | 100      | ?          | ?         |      1,761.203 ns |     1.00 |          - | 
| DefaultEcs        | ComponentEvents_DefaultEcs        | 100      | ?          | ?         |      2,578.369 ns |     1.46 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs           | 100      | ?          | ?         |      4,487.345 ns |     2.55 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet          | 100      | ?          | ?         |     11,125.678 ns |     6.32 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 1          | ?         |      1,071.071 ns |     1.00 |     5456 B | 
| Arch              | CreateBulk_Arch                   | 100      | 1          | ?         |     12,068.028 ns |    11.27 |    99544 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 1          | ?         |     17,689.897 ns |    16.52 |   210712 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 3          | ?         |      1,583.000 ns |     1.00 |     9712 B | 
| Arch              | CreateBulk_Arch                   | 100      | 3          | ?         |      9,705.438 ns |     6.14 |    75024 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 3          | ?         |     25,463.600 ns |    16.11 |   214448 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 1          | ?         |      1,339.553 ns |     0.43 |     7048 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 1          | ?         |      3,106.786 ns |     1.00 |     5456 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 1          | ?         |      3,787.125 ns |     1.22 |    12960 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 1          | ?         |      5,463.976 ns |     1.76 |    86264 B | 
| Arch              | CreateEntity_Arch                 | 100      | 1          | ?         |      6,619.000 ns |     2.13 |    44960 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 1          | ?         |      8,811.000 ns |     2.84 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 1          | ?         |     11,383.429 ns |     3.67 |    18832 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 1          | ?         |     13,560.800 ns |     4.37 |    42896 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 1          | ?         |     38,366.974 ns |    12.35 |   252376 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 3          | ?         |      2,796.469 ns |     1.00 |     9712 B | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 3          | ?         |      3,181.657 ns |     1.14 |    19672 B | 
| Arch              | CreateEntity_Arch                 | 100      | 3          | ?         |      5,929.077 ns |     2.12 |    32712 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 3          | ?         |      7,705.333 ns |     2.76 |    23368 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 3          | ?         |      8,907.526 ns |     3.19 |   121896 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 3          | ?         |     16,753.923 ns |     6.00 |    54400 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 3          | ?         |     17,758.820 ns |     6.36 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 3          | ?         |     21,109.786 ns |     7.56 |    27184 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 3          | ?         |    103,234.786 ns |    36.95 |   395856 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs            | ?        | ?          | ?         |         74.491 ns |     0.24 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                | ?        | ?          | ?         |        316.953 ns |     1.00 |     7024 B | 
| Myriad            | CreateWorld_Myriad                | ?        | ?          | ?         |        849.346 ns |     2.68 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam              | ?        | ?          | ?         |      1,451.068 ns |     4.58 |    58944 B | 
| Arch              | CreateWorld_Arch                  | ?        | ?          | ?         |      2,866.254 ns |     9.04 |    28624 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                | ?        | ?          | ?         |      4,311.391 ns |    13.60 |     5056 B | 
| fennecs           | CreateWorld_Fennecs               | ?        | ?          | ?         |     15,604.699 ns |    49.24 |   169340 B | 
| TinyEcs           | CreateWorld_TinyEcs               | ?        | ?          | ?         |     51,677.654 ns |   163.07 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet              | ?        | ?          | ?         |    968,213.593 ns | 3,055.26 |     1009 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo               | 100000   | 5          | ?         |  1,604,182.933 ns |     1.00 |      736 B | 
| Flecs.NET         | DeleteEntity_FlecsNet             | 100000   | 5          | ?         |  1,999,569.133 ns |     1.25 |      736 B | 
| Arch              | DeleteEntity_Arch                 | 100000   | 5          | ?         |  2,670,593.462 ns |     1.67 |     3088 B | 
| TinyEcs           | DeleteEntity_TinyEcs              | 100000   | 5          | ?         |  3,454,629.525 ns |     2.15 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs           | 100000   | 5          | ?         |  3,661,191.364 ns |     2.28 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam             | 100000   | 5          | ?         |  4,667,890.233 ns |     2.91 |  6268768 B | 
| Myriad            | DeleteEntity_Myriad               | 100000   | 5          | ?         |  4,670,031.577 ns |     2.91 |  8996128 B | 
| fennecs           | DeleteEntity_Fennecs              | 100000   | 5          | ?         |  5,783,428.067 ns |     3.61 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh               | 100000   | 5          | ?         |  8,877,038.786 ns |     5.53 |  1398360 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 1          | ?         |         65.621 ns |     0.32 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 1          | ?         |        112.921 ns |     0.55 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 1          | ?         |        139.369 ns |     0.68 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 1          | ?         |        204.404 ns |     1.00 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 1          | ?         |        283.211 ns |     1.39 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 1          | ?         |        344.239 ns |     1.68 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 1          | ?         |        583.355 ns |     2.85 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 1          | ?         |        713.575 ns |     3.49 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 1          | ?         |      2,382.329 ns |    11.66 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 5          | ?         |        308.497 ns |     0.76 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 5          | ?         |        407.489 ns |     1.00 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 5          | ?         |        450.431 ns |     1.11 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 5          | ?         |        606.650 ns |     1.49 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 5          | ?         |      1,389.452 ns |     3.41 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 5          | ?         |      1,707.410 ns |     4.19 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 5          | ?         |      3,593.627 ns |     8.82 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 5          | ?         |      4,004.101 ns |     9.83 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 5          | ?         |     14,151.366 ns |    34.73 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 1          | ?         |         44.447 ns |     0.86 |          - | 
| Arch              | QueryComponents_Arch              | 100      | 1          | ?         |         49.282 ns |     0.95 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 1          | ?         |         51.886 ns |     1.00 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 1          | ?         |         67.549 ns |     1.30 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 1          | ?         |         69.606 ns |     1.34 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 1          | ?         |         77.284 ns |     1.49 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 1          | ?         |        139.677 ns |     2.69 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 1          | ?         |        202.282 ns |     3.90 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 1          | ?         |        373.485 ns |     7.20 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Arch              | QueryComponents_Arch              | 100      | 5          | ?         |         51.745 ns |     0.74 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 5          | ?         |         69.722 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 5          | ?         |         71.720 ns |     1.03 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 5          | ?         |        125.449 ns |     1.80 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 5          | ?         |        200.308 ns |     2.87 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 5          | ?         |        272.307 ns |     3.91 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 5          | ?         |        343.136 ns |     4.92 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 5          | ?         |        437.206 ns |     6.27 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 5          | ?         |        777.257 ns |    11.15 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 1          | ?         |     45,813.287 ns |     0.95 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 1          | ?         |     48,205.887 ns |     1.00 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 1          | ?         |     48,972.120 ns |     1.02 |       88 B | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 1          | ?         |     49,174.386 ns |     1.02 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 1          | ?         |     50,104.297 ns |     1.04 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 1          | ?         |     52,791.935 ns |     1.10 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 1          | ?         |     53,040.011 ns |     1.10 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 1          | ?         |     77,883.729 ns |     1.62 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 1          | ?         |    838,153.771 ns |    17.39 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 5          | ?         |     48,002.757 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 5          | ?         |     56,818.254 ns |     1.18 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 5          | ?         |     60,662.994 ns |     1.26 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 5          | ?         |     77,461.327 ns |     1.61 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 5          | ?         |     89,123.133 ns |     1.86 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 5          | ?         |    108,476.599 ns |     2.26 |       88 B | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 5          | ?         |    264,349.551 ns |     5.51 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 5          | ?         |    352,159.044 ns |     7.34 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 5          | ?         |  2,121,156.260 ns |    44.19 |        3 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmented_Morpeh            | 32       | ?          | ?         |          4.580 ns |     0.13 |          - | 
| DefaultEcs        | QueryFragmented_Default           | 32       | ?          | ?         |         12.852 ns |     0.35 |          - | 
| Leopotam.EcsLite  | QueryFragmented_Leopotam          | 32       | ?          | ?         |         24.724 ns |     0.68 |          - | 
| Friflo.Engine.ECS | QueryFragmented_Friflo            | 32       | ?          | ?         |         36.481 ns |     1.00 |          - | 
| Arch              | QueryFragmented_Arch              | 32       | ?          | ?         |         39.137 ns |     1.07 |          - | 
| Myriad            | QueryFragmented_Myriad            | 32       | ?          | ?         |         93.557 ns |     2.56 |          - | 
| TinyEcs           | QueryFragmented_TinyEcs           | 32       | ?          | ?         |        130.990 ns |     3.59 |          - | 
| Flecs.NET         | QueryFragmented_FlecsNet          | 32       | ?          | ?         |        318.400 ns |     8.73 |          - | 
| fennecs           | QueryFragmented_Fennecs           | 32       | ?          | ?         |      1,521.700 ns |    41.71 |      120 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo       | 1000000  | ?          | ?         |      4,667.294 ns |     1.00 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                | 1000000  | ?          | ?         |  1,386,724.375 ns |     1.00 |   560001 B | 
