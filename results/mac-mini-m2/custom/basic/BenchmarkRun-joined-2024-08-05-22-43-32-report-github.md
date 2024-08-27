```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.6 (23G80) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-FKGXIC : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-ABGYIO : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Namespace         | Type                                | Components | RelationCount | Mean              | Ratio    | Allocated  | 
|------------------ |------------------------------------ |----------- |-------------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam        | 1          | ?             |        980.007 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs      | 1          | ?             |      1,471.715 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh          | 1          | ?             |      1,678.318 ns |     0.29 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet        | 1          | ?             |      3,761.335 ns |     0.65 |          - | 
| TinyEcs           | AddRemoveComponents_TinyEcs         | 1          | ?             |      3,960.773 ns |     0.68 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo          | 1          | ?             |      5,831.220 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch            | 1          | ?             |      8,525.986 ns |     1.46 |    12000 B | 
| Myriad            | AddRemoveComponents_Myriad          | 1          | ?             |     18,829.045 ns |     3.23 |          - | 
| fennecs           | AddRemoveComponents_Fennecs         | 1          | ?             |     38,849.256 ns |     6.66 |    86400 B | 
|                   |                                     |            |               |                   |          |            | 
| Scellecs.Morpeh   | AddRemoveComponents_Morpeh          | 5          | ?             |      4,988.959 ns |     0.64 |          - | 
| Leopotam.EcsLite  | AddRemoveComponents_Leopotam        | 5          | ?             |      5,194.646 ns |     0.67 |          - | 
| DefaultEcs        | AddRemoveComponents_DefaultEcs      | 5          | ?             |      7,210.874 ns |     0.93 |          - | 
| Friflo.Engine.ECS | AddRemoveComponents_Friflo          | 5          | ?             |      7,745.333 ns |     1.00 |          - | 
| Arch              | AddRemoveComponents_Arch            | 5          | ?             |     22,665.662 ns |     2.93 |     8800 B | 
| TinyEcs           | AddRemoveComponents_TinyEcs         | 5          | ?             |     29,338.222 ns |     3.79 |          - | 
| Flecs.NET         | AddRemoveComponents_FlecsNet        | 5          | ?             |     37,071.420 ns |     4.79 |          - | 
| Myriad            | AddRemoveComponents_Myriad          | 5          | ?             |     55,408.569 ns |     7.15 |          - | 
| fennecs           | AddRemoveComponents_Fennecs         | 5          | ?             |    323,202.093 ns |    41.73 |   620800 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | ?          | 1             |      5,893.246 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | ?          | 1             |     10,464.985 ns |     1.78 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | ?          | 1             |     15,690.483 ns |     2.66 |          - | 
| Arch              | AddRemoveLinks_Arch                 | ?          | 1             |     69,236.726 ns |    11.75 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs              | ?          | 1             |     93,591.848 ns |    15.88 |   180000 B | 
|                   |                                     |            |               |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | ?          | 100           |    971,489.924 ns |     0.79 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | ?          | 100           |  1,235,883.492 ns |     1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | ?          | 100           |  3,517,734.993 ns |     2.85 |        4 B | 
| Arch              | AddRemoveLinks_Arch                 | ?          | 100           |  4,255,131.307 ns |     3.44 |  2180006 B | 
| fennecs           | AddRemoveLinks_Fennecs              | ?          | 100           | 71,586,623.625 ns |    57.92 | 93124892 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | ?          | 1             |      3,757.585 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | ?          | 1             |     12,371.100 ns |     3.29 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | ?          | 1             |     23,388.494 ns |     6.22 |          - | 
| Arch              | AddRemoveRelations_Arch             | ?          | 1             |     47,963.723 ns |    12.76 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs          | ?          | 1             |     95,473.579 ns |    25.41 |   180000 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | ?          | 10            |     47,277.052 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | ?          | 10            |    154,019.816 ns |     3.26 |          - | 
| Arch              | AddRemoveRelations_Arch             | ?          | 10            |    202,349.127 ns |     4.28 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | ?          | 10            |    284,145.353 ns |     6.01 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs          | ?          | 10            |  1,573,589.210 ns |    33.28 |  2562401 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo       | ?          | ?             |     30,200.285 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet     | ?          | ?             |     95,032.266 ns |     3.15 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs      | ?          | ?             |    189,853.441 ns |     6.29 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch         | ?          | ?             |    435,265.040 ns |    14.41 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs      | ?          | ?             |    960,343.881 ns |    31.80 |  1800001 B | 
|                   |                                     |            |               |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?          | ?             |      4,980.421 ns |     0.58 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?          | ?             |      8,650.421 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?          | ?             |     13,032.864 ns |     1.51 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?          | ?             |     14,361.121 ns |     1.66 |          - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?          | ?             |     16,831.531 ns |     1.95 |          - | 
| Myriad            | CommandBufferAddRemoveT2_Myriad     | ?          | ?             |     27,486.496 ns |     3.18 |          - | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?          | ?             |     48,282.762 ns |     5.58 |     4800 B | 
|                   |                                     |            |               |                   |          |            | 
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?          | ?             |      2,564.836 ns |     0.33 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?          | ?             |      4,423.503 ns |     0.56 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?          | ?             |      7,848.100 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?          | ?             |     11,185.981 ns |     1.43 |          - | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                   | 1          | ?             |      1,056.604 ns |     1.00 |     7856 B | 
| Arch              | CreateBulk_Arch                     | 1          | ?             |      7,323.385 ns |     6.54 |    36736 B | 
| fennecs           | CreateBulk_Fennecs                  | 1          | ?             |     17,903.941 ns |    16.38 |   210712 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | CreateBulk_Friflo                   | 3          | ?             |      1,552.047 ns |     1.00 |    12112 B | 
| Arch              | CreateBulk_Arch                     | 3          | ?             |      8,135.800 ns |     5.14 |    28592 B | 
| fennecs           | CreateBulk_Fennecs                  | 3          | ?             |     25,202.862 ns |    16.08 |   214448 B | 
|                   |                                     |            |               |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam               | 1          | ?             |      1,372.235 ns |     0.30 |     7048 B | 
| DefaultEcs        | CreateEntity_DefaultEcs             | 1          | ?             |      3,745.386 ns |     0.82 |    12960 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo                 | 1          | ?             |      4,577.218 ns |     1.00 |    11600 B | 
| TinyEcs           | CreateEntity_TinyEcs                | 1          | ?             |      4,892.643 ns |     1.07 |    86264 B | 
| Arch              | CreateEntity_Arch                   | 1          | ?             |      8,045.205 ns |     1.76 |    36400 B | 
| Flecs.NET         | CreateEntity_FlecsNet               | 1          | ?             |      9,041.873 ns |     1.98 |      736 B | 
| Myriad            | CreateEntity_Myriad                 | 1          | ?             |     10,996.933 ns |     2.40 |    18936 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh                 | 1          | ?             |     13,477.400 ns |     2.95 |    42896 B | 
| fennecs           | CreateEntity_Fennecs                | 1          | ?             |     37,281.615 ns |     8.17 |   252376 B | 
|                   |                                     |            |               |                   |          |            | 
| Leopotam.EcsLite  | CreateEntity_Leopotam               | 3          | ?             |      3,160.647 ns |     0.76 |    19672 B | 
| Friflo.Engine.ECS | CreateEntity_Friflo                 | 3          | ?             |      4,144.564 ns |     1.00 |    15856 B | 
| Arch              | CreateEntity_Arch                   | 3          | ?             |      7,007.469 ns |     1.69 |    28256 B | 
| DefaultEcs        | CreateEntity_DefaultEcs             | 3          | ?             |      7,729.194 ns |     1.87 |    23368 B | 
| TinyEcs           | CreateEntity_TinyEcs                | 3          | ?             |      8,389.250 ns |     2.01 |   121896 B | 
| Scellecs.Morpeh   | CreateEntity_Morpeh                 | 3          | ?             |     16,760.667 ns |     4.05 |    54400 B | 
| Flecs.NET         | CreateEntity_FlecsNet               | 3          | ?             |     18,961.417 ns |     4.58 |      736 B | 
| Myriad            | CreateEntity_Myriad                 | 3          | ?             |     20,961.071 ns |     5.03 |    27288 B | 
| fennecs           | CreateEntity_Fennecs                | 3          | ?             |    102,270.333 ns |    24.54 |   395856 B | 
|                   |                                     |            |               |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs              | ?          | ?             |         74.728 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                  | ?          | ?             |        238.704 ns |     1.00 |     3952 B | 
| Myriad            | CreateWorld_Myriad                  | ?          | ?             |        808.308 ns |     3.39 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam                | ?          | ?             |      1,454.448 ns |     6.09 |    58944 B | 
| Arch              | CreateWorld_Arch                    | ?          | ?             |      3,373.307 ns |    14.13 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                  | ?          | ?             |      4,320.532 ns |    18.10 |     5056 B | 
| fennecs           | CreateWorld_Fennecs                 | ?          | ?             |     15,385.229 ns |    64.46 |   169340 B | 
| TinyEcs           | CreateWorld_TinyEcs                 | ?          | ?             |     50,222.178 ns |   210.31 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet                | ?          | ?             |    987,053.092 ns | 4,134.98 |     1009 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo                 | ?          | ?             |  1,617,947.038 ns |     1.00 |      736 B | 
| Myriad            | DeleteEntity_Myriad                 | ?          | ?             |  1,852,693.214 ns |     1.15 |  4196080 B | 
| Flecs.NET         | DeleteEntity_FlecsNet               | ?          | ?             |  1,994,815.214 ns |     1.23 |      736 B | 
| Arch              | DeleteEntity_Arch                   | ?          | ?             |  2,666,092.000 ns |     1.65 |     3088 B | 
| TinyEcs           | DeleteEntity_TinyEcs                | ?          | ?             |  3,276,853.682 ns |     2.03 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs             | ?          | ?             |  3,676,121.923 ns |     2.27 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam               | ?          | ?             |  4,588,373.179 ns |     2.84 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs                | ?          | ?             |  5,618,417.083 ns |     3.47 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh                 | ?          | ?             |  8,785,261.831 ns |     5.41 |  1398360 B | 
|                   |                                     |            |               |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam           | 1          | ?             |         65.712 ns |     0.32 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs         | 1          | ?             |        112.885 ns |     0.55 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh             | 1          | ?             |        135.437 ns |     0.66 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo             | 1          | ?             |        204.090 ns |     1.00 |          - | 
| Arch              | GetSetComponents_Arch               | 1          | ?             |        287.552 ns |     1.41 |          - | 
| Myriad            | GetSetComponents_Myriad             | 1          | ?             |        345.098 ns |     1.69 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet           | 1          | ?             |        584.608 ns |     2.86 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs            | 1          | ?             |        714.294 ns |     3.50 |          - | 
| fennecs           | GetSetComponents_Fennecs            | 1          | ?             |      2,383.753 ns |    11.68 |          - | 
|                   |                                     |            |               |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponents_Leopotam           | 5          | ?             |        314.777 ns |     0.77 |          - | 
| Friflo.Engine.ECS | GetSetComponents_Friflo             | 5          | ?             |        410.637 ns |     1.00 |          - | 
| DefaultEcs        | GetSetComponents_DefaultEcs         | 5          | ?             |        450.435 ns |     1.10 |          - | 
| Scellecs.Morpeh   | GetSetComponents_Morpeh             | 5          | ?             |        612.833 ns |     1.49 |          - | 
| Arch              | GetSetComponents_Arch               | 5          | ?             |      1,573.497 ns |     3.83 |          - | 
| Myriad            | GetSetComponents_Myriad             | 5          | ?             |      1,736.120 ns |     4.23 |          - | 
| Flecs.NET         | GetSetComponents_FlecsNet           | 5          | ?             |      2,692.631 ns |     6.56 |          - | 
| TinyEcs           | GetSetComponents_TinyEcs            | 5          | ?             |      4,014.600 ns |     9.77 |          - | 
| fennecs           | GetSetComponents_Fennecs            | 5          | ?             |     14,270.492 ns |    34.75 |          - | 
|                   |                                     |            |               |                   |          |            | 
| DefaultEcs        | QueryComponents_DefaultEcs          | 1          | ?             |         44.474 ns |     0.91 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo              | 1          | ?             |         48.686 ns |     1.00 |          - | 
| TinyEcs           | QueryComponents_TinyEcs             | 1          | ?             |         66.514 ns |     1.37 |          - | 
| Myriad            | QueryComponents_Myriad              | 1          | ?             |         69.577 ns |     1.43 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam            | 1          | ?             |         77.360 ns |     1.59 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet            | 1          | ?             |        140.609 ns |     2.89 |          - | 
| fennecs           | QueryComponents_Fennecs             | 1          | ?             |        196.662 ns |     4.04 |       88 B | 
| Arch              | QueryComponents_Arch                | 1          | ?             |        300.159 ns |     6.17 |          - | 
| Scellecs.Morpeh   | QueryComponents_Morpeh              | 1          | ?             |        373.226 ns |     7.66 |          - | 
|                   |                                     |            |               |                   |          |            | 
| Myriad            | QueryComponents_Myriad              | 5          | ?             |         70.814 ns |     0.63 |          - | 
| Friflo.Engine.ECS | QueryComponents_Friflo              | 5          | ?             |        113.295 ns |     1.00 |          - | 
| TinyEcs           | QueryComponents_TinyEcs             | 5          | ?             |        126.507 ns |     1.12 |          - | 
| Flecs.NET         | QueryComponents_FlecsNet            | 5          | ?             |        200.810 ns |     1.77 |          - | 
| DefaultEcs        | QueryComponents_DefaultEcs          | 5          | ?             |        271.119 ns |     2.39 |          - | 
| Leopotam.EcsLite  | QueryComponents_Leopotam            | 5          | ?             |        339.168 ns |     2.99 |          - | 
| Arch              | QueryComponents_Arch                | 5          | ?             |        343.736 ns |     3.03 |          - | 
| fennecs           | QueryComponents_Fennecs             | 5          | ?             |        441.510 ns |     3.90 |       88 B | 
| Scellecs.Morpeh   | QueryComponents_Morpeh              | 5          | ?             |        781.210 ns |     6.89 |          - | 
|                   |                                     |            |               |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmentedT1_Morpeh            | ?          | ?             |          4.594 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmentedT1_Default           | ?          | ?             |         12.837 ns |     0.32 |          - | 
| Leopotam.EcsLite  | QueryFragmentedT1_Leopotam          | ?          | ?             |         24.432 ns |     0.62 |          - | 
| Friflo.Engine.ECS | QueryFragmentedT1_Friflo            | ?          | ?             |         39.574 ns |     1.00 |          - | 
| Myriad            | QueryFragmentedT1_Myriad            | ?          | ?             |         92.886 ns |     2.35 |          - | 
| TinyEcs           | QueryFragmentedT1_TinyEcs           | ?          | ?             |        131.011 ns |     3.31 |          - | 
| Arch              | QueryFragmentedT1_Arch              | ?          | ?             |        226.708 ns |     5.73 |          - | 
| Flecs.NET         | QueryFragmentedT1_FlecsNet          | ?          | ?             |        319.156 ns |     8.06 |          - | 
| fennecs           | QueryFragmentedT1_Fennecs           | ?          | ?             |      1,533.006 ns |    38.73 |      120 B | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo         | ?          | ?             |      4,738.152 ns |     1.00 |          - | 
|                   |                                     |            |               |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                  | ?          | ?             |  1,514,657.781 ns |     1.00 |   560001 B | 
