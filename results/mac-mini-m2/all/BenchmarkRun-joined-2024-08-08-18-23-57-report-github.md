```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.6 (23G80) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-EKRZCJ : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-NAMQBH : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Namespace         | Type                              | Entities | Components | Relations | Mean              | Ratio    | Allocated  | 
|------------------ |---------------------------------- |--------- |----------- |---------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 1          | ?         |        981.124 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 1          | ?         |      1,431.875 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 1          | ?         |      1,676.880 ns |     0.29 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 1          | ?         |      3,761.297 ns |     0.65 |          - | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 1          | ?         |      3,984.444 ns |     0.69 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 1          | ?         |      5,787.121 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 1          | ?         |      8,438.609 ns |     1.46 |    12000 B | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 1          | ?         |     19,044.506 ns |     3.29 |          - | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 1          | ?         |     38,594.518 ns |     6.67 |    86400 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh        | 100      | 5          | ?         |      4,988.723 ns |     0.64 |          - | 
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam      | 100      | 5          | ?         |      5,118.056 ns |     0.66 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs    | 100      | 5          | ?         |      7,120.456 ns |     0.92 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo        | 100      | 5          | ?         |      7,779.866 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch          | 100      | 5          | ?         |     23,106.157 ns |     2.97 |     8800 B | 
| TinyEcs           | AddRemoveComponents_TinyEcs       | 100      | 5          | ?         |     29,867.362 ns |     3.84 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet      | 100      | 5          | ?         |     37,030.476 ns |     4.76 |          - | 
| Myriad            | AddRemoveComponents_Myriad        | 100      | 5          | ?         |     54,960.005 ns |     7.06 |          - | 
| fennecs           | AddRemoveComponents_Fennecs       | 100      | 5          | ?         |    307,458.103 ns |    39.52 |   620800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 1         |      5,912.556 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 1         |     10,552.895 ns |     1.78 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 1         |     15,864.012 ns |     2.68 |          - | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 1         |     72,628.706 ns |    12.28 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 1         |     94,414.249 ns |    15.97 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet           | 100      | ?          | 100       |    976,119.140 ns |     0.78 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo             | 100      | ?          | 100       |  1,252,632.964 ns |     1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch               | 100      | ?          | 100       |  4,353,920.031 ns |     3.48 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs            | 100      | ?          | 100       |  4,694,910.763 ns |     3.75 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs            | 100      | ?          | 100       | 71,847,234.879 ns |    57.35 | 93124905 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 1         |      3,761.452 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 1         |     12,266.748 ns |     3.26 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 1         |     23,416.350 ns |     6.22 |          - | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 1         |     48,360.775 ns |    12.86 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 1         |     96,676.160 ns |    25.71 |   180000 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo         | 100      | ?          | 10        |     47,569.594 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet       | 100      | ?          | 10        |    158,925.695 ns |     3.34 |          - | 
| Arch              | AddRemoveRelations_Arch           | 100      | ?          | 10        |    204,024.890 ns |     4.29 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs        | 100      | ?          | 10        |    282,603.993 ns |     5.94 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs        | 100      | ?          | 10        |  1,578,632.547 ns |    33.20 |  2568001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo     | 100      | ?          | ?         |     25,754.962 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet   | 100      | ?          | ?         |     94,588.120 ns |     3.67 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs    | 100      | ?          | ?         |    191,267.337 ns |     7.43 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch       | 100      | ?          | ?         |    433,217.245 ns |    16.82 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs    | 100      | ?          | ?         |    929,259.379 ns |    36.08 |  1800001 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemove_Morpeh     | 100      | ?          | ?         |      5,020.583 ns |     0.58 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemove_Friflo     | 100      | ?          | ?         |      8,665.932 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemove_TinyEcs    | 100      | ?          | ?         |     12,907.027 ns |     1.49 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemove_FlecsNet   | 100      | ?          | ?         |     14,344.542 ns |     1.65 |          - | 
| DefaultEcs        | CommandBufferAddRemove_DefaultEcs | 100      | ?          | ?         |     16,319.677 ns |     1.88 |          - | 
| Myriad            | CommandBufferAddRemove_Myriad     | 100      | ?          | ?         |     27,799.021 ns |     3.21 |          - | 
| Arch              | CommandBufferAddRemove_Arch       | 100      | ?          | ?         |     48,811.041 ns |     5.63 |     4800 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | ComponentEvents_DefaultEcs        | 100      | ?          | ?         |      2,605.541 ns |     0.33 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs           | 100      | ?          | ?         |      4,395.451 ns |     0.56 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo            | 100      | ?          | ?         |      7,905.856 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet          | 100      | ?          | ?         |     11,251.277 ns |     1.42 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 1          | ?         |        988.167 ns |     1.00 |     7856 B | 
| Arch              | CreateBulk_Arch                   | 100      | 1          | ?         |      7,360.867 ns |     7.53 |    36736 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 1          | ?         |     19,065.286 ns |    19.48 |   210712 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                 | 100      | 3          | ?         |      1,605.704 ns |     1.00 |    12112 B | 
| Arch              | CreateBulk_Arch                   | 100      | 3          | ?         |      7,906.549 ns |     4.88 |    28592 B | 
| fennecs           | CreateBulk_Fennecs                | 100      | 3          | ?         |     25,458.071 ns |    15.74 |   214448 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 1          | ?         |      1,374.593 ns |     0.30 |     7048 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 1          | ?         |      3,894.720 ns |     0.85 |    12960 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 1          | ?         |      4,574.500 ns |     1.00 |    11600 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 1          | ?         |      5,536.062 ns |     1.22 |    86264 B | 
| Arch              | CreateEntity_Arch                 | 100      | 1          | ?         |      7,948.733 ns |     1.74 |    36400 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 1          | ?         |      8,558.708 ns |     1.87 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 1          | ?         |     11,178.043 ns |     2.45 |    18936 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 1          | ?         |     13,511.571 ns |     2.99 |    42896 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 1          | ?         |     37,324.667 ns |     8.22 |   252376 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam             | 100      | 3          | ?         |      3,163.156 ns |     0.82 |    19672 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo               | 100      | 3          | ?         |      3,877.121 ns |     1.00 |    15856 B | 
| Arch              | CreateEntity_Arch                 | 100      | 3          | ?         |      6,384.333 ns |     1.65 |    28256 B | 
| DefaultEcs        | CreateEntity_DefaultEcs           | 100      | 3          | ?         |      7,615.786 ns |     1.95 |    23368 B | 
| TinyEcs           | CreateEntity_TinyEcs              | 100      | 3          | ?         |      8,953.293 ns |     2.31 |   121896 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh               | 100      | 3          | ?         |     16,683.667 ns |     4.28 |    54400 B | 
| Flecs.NET         | CreateEntity_FlecsNet             | 100      | 3          | ?         |     17,391.000 ns |     4.55 |      736 B | 
| Myriad            | CreateEntity_Myriad               | 100      | 3          | ?         |     21,014.100 ns |     5.39 |    27288 B | 
| fennecs           | CreateEntity_Fennecs              | 100      | 3          | ?         |    103,193.071 ns |    26.41 |   395856 B | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs            | ?        | ?          | ?         |         74.537 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                | ?        | ?          | ?         |        238.857 ns |     1.00 |     3952 B | 
| Myriad            | CreateWorld_Myriad                | ?        | ?          | ?         |        802.669 ns |     3.36 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam              | ?        | ?          | ?         |      1,443.729 ns |     6.04 |    58944 B | 
| Arch              | CreateWorld_Arch                  | ?        | ?          | ?         |      3,369.511 ns |    14.11 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                | ?        | ?          | ?         |      4,295.665 ns |    17.98 |     5056 B | 
| fennecs           | CreateWorld_Fennecs               | ?        | ?          | ?         |     21,295.124 ns |    89.16 |   169364 B | 
| TinyEcs           | CreateWorld_TinyEcs               | ?        | ?          | ?         |     51,588.420 ns |   215.98 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet              | ?        | ?          | ?         |  1,033,699.449 ns | 4,265.55 |     1009 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo               | 100000   | ?          | ?         |  1,590,691.846 ns |     1.00 |      736 B | 
| Myriad            | DeleteEntity_Myriad               | 100000   | ?          | ?         |  1,917,754.189 ns |     1.20 |  4196080 B | 
| Flecs.NET         | DeleteEntity_FlecsNet             | 100000   | ?          | ?         |  1,985,879.083 ns |     1.25 |      736 B | 
| Arch              | DeleteEntity_Arch                 | 100000   | ?          | ?         |  2,899,945.705 ns |     1.73 |     3088 B | 
| TinyEcs           | DeleteEntity_TinyEcs              | 100000   | ?          | ?         |  3,382,786.000 ns |     2.13 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs           | 100000   | ?          | ?         |  3,684,181.868 ns |     2.31 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam             | 100000   | ?          | ?         |  4,814,687.071 ns |     3.03 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs              | 100000   | ?          | ?         |  5,720,832.846 ns |     3.60 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh               | 100000   | ?          | ?         |  8,842,465.778 ns |     5.55 |  1398360 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 1          | ?         |         65.691 ns |     0.32 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 1          | ?         |        115.632 ns |     0.57 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 1          | ?         |        141.457 ns |     0.70 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 1          | ?         |        202.901 ns |     1.00 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 1          | ?         |        288.412 ns |     1.42 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 1          | ?         |        346.096 ns |     1.71 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 1          | ?         |        582.540 ns |     2.87 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 1          | ?         |        729.995 ns |     3.60 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 1          | ?         |      2,369.119 ns |    11.68 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam         | 100      | 5          | ?         |        312.340 ns |     0.76 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo           | 100      | 5          | ?         |        410.966 ns |     1.00 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs       | 100      | 5          | ?         |        457.825 ns |     1.11 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh           | 100      | 5          | ?         |        614.871 ns |     1.50 |          - | 
| Arch              | GetSetComponents_Arch             | 100      | 5          | ?         |      1,586.688 ns |     3.86 |          - | 
| Myriad            | GetSetComponents_Myriad           | 100      | 5          | ?         |      1,744.219 ns |     4.24 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet         | 100      | 5          | ?         |      2,690.086 ns |     6.55 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs          | 100      | 5          | ?         |      4,004.393 ns |     9.74 |          - | 
| fennecs           | GetSetComponents_Fennecs          | 100      | 5          | ?         |     14,345.827 ns |    34.91 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 1          | ?         |         44.319 ns |     0.86 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 1          | ?         |         51.273 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 1          | ?         |         65.811 ns |     1.28 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 1          | ?         |         67.833 ns |     1.32 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 1          | ?         |         77.356 ns |     1.51 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 1          | ?         |        141.093 ns |     2.75 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 1          | ?         |        203.608 ns |     3.97 |       88 B | 
| Arch              | QueryComponents_Arch              | 100      | 1          | ?         |        299.398 ns |     5.84 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 1          | ?         |        374.050 ns |     7.30 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100      | 5          | ?         |         65.330 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100      | 5          | ?         |         71.256 ns |     1.09 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100      | 5          | ?         |        127.441 ns |     1.95 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100      | 5          | ?         |        200.597 ns |     3.07 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100      | 5          | ?         |        272.272 ns |     4.17 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100      | 5          | ?         |        340.565 ns |     5.21 |          - | 
| Arch              | QueryComponents_Arch              | 100      | 5          | ?         |        341.054 ns |     5.22 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100      | 5          | ?         |        441.706 ns |     6.76 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100      | 5          | ?         |        782.979 ns |    11.99 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 1          | ?         |     45,890.802 ns |     0.94 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 1          | ?         |     48,631.778 ns |     1.00 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 1          | ?         |     49,366.218 ns |     1.02 |       88 B | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 1          | ?         |     49,899.346 ns |     1.03 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 1          | ?         |     50,214.852 ns |     1.03 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 1          | ?         |     51,355.001 ns |     1.06 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 1          | ?         |     77,551.318 ns |     1.60 |          - | 
| Arch              | QueryComponents_Arch              | 100000   | 1          | ?         |    211,165.531 ns |     4.34 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 1          | ?         |    855,866.692 ns |    17.60 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | QueryComponents_Friflo            | 100000   | 5          | ?         |     48,055.904 ns |     1.00 |          - | 
| Myriad            | QueryComponents_Myriad            | 100000   | 5          | ?         |     56,872.027 ns |     1.18 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet          | 100000   | 5          | ?         |     77,777.170 ns |     1.62 |          - | 
| TinyEcs           | QueryComponents_TinyEcs           | 100000   | 5          | ?         |     89,260.356 ns |     1.86 |          - | 
| fennecs           | QueryComponents_Fennecs           | 100000   | 5          | ?         |    108,646.374 ns |     2.26 |       88 B | 
| Arch              | QueryComponents_Arch              | 100000   | 5          | ?         |    229,269.514 ns |     4.77 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs        | 100000   | 5          | ?         |    318,011.143 ns |     6.62 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam          | 100000   | 5          | ?         |    350,145.974 ns |     7.29 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh            | 100000   | 5          | ?         |  1,979,985.689 ns |    41.20 |        1 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmented_Morpeh            | 32       | ?          | ?         |          4.591 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmented_Default           | 32       | ?          | ?         |         12.838 ns |     0.35 |          - | 
| Leopotam.EcsLite  | QueryFragmented_Leopotam          | 32       | ?          | ?         |         24.771 ns |     0.67 |          - | 
| Friflo.Engine.ECS | QueryFragmented_Friflo            | 32       | ?          | ?         |         37.074 ns |     1.00 |          - | 
| Myriad            | QueryFragmented_Myriad            | 32       | ?          | ?         |         94.408 ns |     2.55 |          - | 
| TinyEcs           | QueryFragmented_TinyEcs           | 32       | ?          | ?         |        130.896 ns |     3.53 |          - | 
| Arch              | QueryFragmented_Arch              | 32       | ?          | ?         |        228.839 ns |     6.19 |          - | 
| Flecs.NET         | QueryFragmented_FlecsNet          | 32       | ?          | ?         |        321.093 ns |     8.66 |          - | 
| fennecs           | QueryFragmented_Fennecs           | 32       | ?          | ?         |      1,521.569 ns |    41.04 |      120 B | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo       | 1000000  | ?          | ?         |      4,745.586 ns |     1.00 |          - | 
|                   |                                   |          |            |           |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                | 1000000  | ?          | ?         |  1,512,413.691 ns |     1.00 |   560001 B | 
