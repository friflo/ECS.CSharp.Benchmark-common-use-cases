```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.6.1 (23G93) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-TCXFFF : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-OFEMVI : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Namespace         | Type                              | Entities | Components | Relations | Mean              | Ratio    | Allocated  | 
|------------------ |---------------------------------- |--------- |----------- |---------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 1          | ?         |        985.810 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 1          | ?         |      1,439.503 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 1          | ?         |      1,682.917 ns |     0.29 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 1          | ?         |      3,758.536 ns |     0.64 |          - | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 1          | ?         |      3,971.681 ns |     0.68 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 1          | ?         |      4,352.262 ns |     0.75 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 1          | ?         |      5,834.352 ns |     1.00 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 1          | ?         |     20,217.652 ns |     3.47 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 1          | ?         |     38,613.307 ns |     6.62 |    86400 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 5          | ?         |      5,007.156 ns |     0.64 |          - | 
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 5          | ?         |      5,132.171 ns |     0.66 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 5          | ?         |      7,171.192 ns |     0.92 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 5          | ?         |      7,788.221 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 5          | ?         |     22,868.640 ns |     2.94 |     8800 B | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 5          | ?         |     29,618.611 ns |     3.80 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 5          | ?         |     35,132.997 ns |     4.51 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 5          | ?         |     56,300.728 ns |     7.23 |       96 B | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 5          | ?         |    307,935.863 ns |    39.54 |   620800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 1         |      5,921.550 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 1         |     10,282.088 ns |     1.74 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 1         |     15,678.419 ns |     2.65 |          - | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 1         |     62,891.196 ns |    10.62 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 1         |     94,166.898 ns |    15.90 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 100       |    962,166.504 ns |     0.76 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 100       |  1,271,413.272 ns |     1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 100       |  3,473,835.091 ns |     2.73 |        4 B | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 100       |  3,880,333.865 ns |     3.05 |  2180003 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 100       | 71,774,787.305 ns |    56.45 | 93124905 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 1         |      3,763.653 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 1         |     11,693.794 ns |     3.11 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 1         |     23,659.208 ns |     6.29 |          - | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 1         |     42,171.139 ns |    11.20 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 1         |     95,729.440 ns |    25.44 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 100       |     47,427.077 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 100       |    150,227.799 ns |     3.17 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 100       |    290,274.470 ns |     6.12 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 100       |  1,574,040.357 ns |    33.19 |  2540001 B | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 100       |  1,594,050.336 ns |    33.61 |  2180001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo     | 100      | ?          | ?         |     25,644.702 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet   | 100      | ?          | ?         |     91,912.892 ns |     3.58 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs    | 100      | ?          | ?         |    190,298.086 ns |     7.42 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch       | 100      | ?          | ?         |    396,568.189 ns |    15.46 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs    | 100      | ?          | ?         |    950,019.792 ns |    37.05 |  1800001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemove_Morpeh     | 100      | ?          | ?         |      5,047.926 ns |     0.58 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemove_Friflo     | 100      | ?          | ?         |      8,711.511 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemove_TinyEcs    | 100      | ?          | ?         |     12,916.958 ns |     1.48 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemove_FlecsNet   | 100      | ?          | ?         |     14,375.990 ns |     1.65 |          - | 
| DefaultEcs        | CommandBufferAddRemove_DefaultEcs | 100      | ?          | ?         |     16,865.455 ns |     1.94 |          - | 
| Myriad            | CommandBufferAddRemove_Myriad     | 100      | ?          | ?         |     28,484.521 ns |     3.27 |       96 B | 
| Arch              | CommandBufferAddRemove_Arch       | 100      | ?          | ?         |     46,978.501 ns |     5.39 |    12800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | ComponentEvents_DefaultEcs        | 100      | ?          | ?         |      2,625.651 ns |     0.34 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs           | 100      | ?          | ?         |      4,405.523 ns |     0.57 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo            | 100      | ?          | ?         |      7,768.015 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet          | 100      | ?          | ?         |     11,260.194 ns |     1.45 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 1          | ?         |        966.851 ns |     1.00 |     7856 B | 
| Arch              | CreateBulk_Arch                   | 100      | 1          | ?         |      9,553.833 ns |     9.92 |    70736 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 1          | ?         |     17,929.269 ns |    18.61 |   210712 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 3          | ?         |      1,459.680 ns |     1.00 |    12112 B | 
| Arch              | CreateBulk_Arch                   | 100      | 3          | ?         |      7,335.929 ns |     5.03 |    54408 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 3          | ?         |     25,443.000 ns |    17.46 |   214448 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 1          | ?         |      1,357.682 ns |     0.31 |     7048 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 1          | ?         |      3,765.000 ns |     0.85 |    12960 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 1          | ?         |      4,443.909 ns |     1.00 |    11600 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 1          | ?         |      4,910.286 ns |     1.11 |    86264 B | 
| Arch              | CreateEntity_Arch                 | 100      | 1          | ?         |      6,115.231 ns |     1.38 |    36728 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 1          | ?         |      8,816.286 ns |     1.98 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 1          | ?         |     11,273.357 ns |     2.54 |    18984 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 1          | ?         |     13,538.286 ns |     3.05 |    42896 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 1          | ?         |     37,021.933 ns |     8.33 |   252376 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 3          | ?         |      3,176.000 ns |     0.78 |    19672 B | 
| Arch              | CreateEntity_Arch                 | 100      | 3          | ?         |      3,536.833 ns |     0.87 |    20344 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 3          | ?         |      4,074.640 ns |     1.01 |    15856 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 3          | ?         |      7,646.933 ns |     1.89 |    23368 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 3          | ?         |      8,327.538 ns |     2.06 |   121896 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 3          | ?         |     17,291.400 ns |     4.27 |    54400 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 3          | ?         |     18,679.083 ns |     4.61 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 3          | ?         |     20,757.933 ns |     5.12 |    27336 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 3          | ?         |     99,196.143 ns |    24.48 |   395856 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs            | ?        | ?          | ?         |         74.115 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                | ?        | ?          | ?         |        239.799 ns |     1.00 |     3952 B | 
| Myriad            | CreateWorld_Myriad                | ?        | ?          | ?         |        815.250 ns |     3.40 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam              | ?        | ?          | ?         |      1,472.712 ns |     6.14 |    58944 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                | ?        | ?          | ?         |      4,307.250 ns |    17.96 |     5056 B | 
| Arch              | CreateWorld_Arch                  | ?        | ?          | ?         |      6,042.976 ns |    25.20 |    69728 B | 
| fennecs           | CreateWorld_Fennecs               | ?        | ?          | ?         |     21,763.380 ns |    90.76 |   169364 B | 
| TinyEcs           | CreateWorld_TinyEcs               | ?        | ?          | ?         |     51,964.205 ns |   216.70 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet              | ?        | ?          | ?         |    970,774.218 ns | 4,048.38 |     1009 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo               | 100000   | 5          | ?         |  1,626,188.667 ns |     1.00 |      736 B | 
| Flecs.NET         | DeleteEntity_FlecsNet             | 100000   | 5          | ?         |  1,984,794.750 ns |     1.22 |      736 B | 
| Arch              | DeleteEntity_Arch                 | 100000   | 5          | ?         |  3,241,003.250 ns |     1.99 |  2096360 B | 
| TinyEcs           | DeleteEntity_TinyEcs              | 100000   | 5          | ?         |  3,318,313.919 ns |     2.04 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs           | 100000   | 5          | ?         |  3,719,502.400 ns |     2.29 |  3200736 B | 
| Myriad            | DeleteEntity_Myriad               | 100000   | 5          | ?         |  4,482,273.429 ns |     2.76 |  8996128 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam             | 100000   | 5          | ?         |  4,634,294.200 ns |     2.85 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs              | 100000   | 5          | ?         |  5,748,444.083 ns |     3.53 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh               | 100000   | 5          | ?         |  8,949,015.914 ns |     5.50 |  1398360 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 1          | ?         |         65.781 ns |     0.32 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 1          | ?         |        115.637 ns |     0.56 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 1          | ?         |        138.129 ns |     0.67 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 1          | ?         |        205.462 ns |     1.00 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 1          | ?         |        267.588 ns |     1.30 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 1          | ?         |        344.613 ns |     1.68 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 1          | ?         |        584.322 ns |     2.84 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 1          | ?         |        723.724 ns |     3.52 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 1          | ?         |      2,379.785 ns |    11.58 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 5          | ?         |        311.356 ns |     0.76 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 5          | ?         |        409.938 ns |     1.00 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 5          | ?         |        456.301 ns |     1.11 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 5          | ?         |        613.413 ns |     1.50 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 5          | ?         |      1,314.370 ns |     3.21 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 5          | ?         |      1,724.947 ns |     4.21 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 5          | ?         |      2,647.317 ns |     6.46 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 5          | ?         |      4,009.356 ns |     9.78 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 5          | ?         |     14,193.057 ns |    34.62 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 1          | ?         |         45.068 ns |     0.87 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 1          | ?         |         51.903 ns |     1.00 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 1          | ?         |         68.294 ns |     1.32 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 1          | ?         |         77.329 ns |     1.49 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 1          | ?         |         78.523 ns |     1.51 |          - | 
| Arch              | QueryComponents_Arch              | 100      | 1          | ?         |         79.111 ns |     1.52 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 1          | ?         |        137.251 ns |     2.64 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 1          | ?         |        201.668 ns |     3.89 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 1          | ?         |        373.829 ns |     7.20 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 5          | ?         |         69.759 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 5          | ?         |         71.642 ns |     1.03 |          - | 
| Arch              | QueryComponents_Arch              | 100      | 5          | ?         |         80.761 ns |     1.16 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 5          | ?         |        120.683 ns |     1.73 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 5          | ?         |        198.075 ns |     2.84 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 5          | ?         |        271.946 ns |     3.90 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 5          | ?         |        338.946 ns |     4.86 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 5          | ?         |        437.448 ns |     6.27 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 5          | ?         |        780.840 ns |    11.19 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 1          | ?         |     47,494.963 ns |     0.96 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 1          | ?         |     49,136.753 ns |     1.00 |       88 B | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 1          | ?         |     49,386.870 ns |     1.00 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 1          | ?         |     50,256.196 ns |     1.02 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 1          | ?         |     50,741.461 ns |     1.03 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 1          | ?         |     51,555.627 ns |     1.04 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 1          | ?         |     52,084.634 ns |     1.06 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 1          | ?         |     78,025.685 ns |     1.58 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 1          | ?         |    860,788.458 ns |    17.44 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 5          | ?         |     47,793.683 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 5          | ?         |     56,282.649 ns |     1.18 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 5          | ?         |     60,621.061 ns |     1.27 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 5          | ?         |     77,711.746 ns |     1.63 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 5          | ?         |     86,946.892 ns |     1.82 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 5          | ?         |    106,963.285 ns |     2.24 |       88 B | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 5          | ?         |    318,023.679 ns |     6.65 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 5          | ?         |    341,770.536 ns |     7.15 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 5          | ?         |  1,787,440.935 ns |    37.40 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmented_Morpeh            | 32       | ?          | ?         |          4.571 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmented_Default           | 32       | ?          | ?         |         12.838 ns |     0.34 |          - | 
| Leopotam.EcsLite  | QueryFragmented_Leopotam          | 32       | ?          | ?         |         24.833 ns |     0.66 |          - | 
| Friflo.Engine.ECS | QueryFragmented_Friflo            | 32       | ?          | ?         |         37.637 ns |     1.00 |          - | 
| Myriad            | QueryFragmented_Myriad            | 32       | ?          | ?         |         93.341 ns |     2.48 |          - | 
| TinyEcs           | QueryFragmented_TinyEcs           | 32       | ?          | ?         |        128.806 ns |     3.42 |          - | 
| Arch              | QueryFragmented_Arch              | 32       | ?          | ?         |        132.446 ns |     3.52 |          - | 
| Flecs.NET         | QueryFragmented_FlecsNet          | 32       | ?          | ?         |        313.306 ns |     8.32 |          - | 
| fennecs           | QueryFragmented_Fennecs           | 32       | ?          | ?         |      1,541.568 ns |    40.96 |      120 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo       | 1000000  | ?          | ?         |      4,738.450 ns |     1.00 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                | 1000000  | ?          | ?         |  1,525,601.177 ns |     1.00 |   560001 B | 
