```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-LOUCDR : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated  | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam      | ?             |        973.054 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs    | ?             |      1,423.788 ns |     0.24 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh        | ?             |      1,846.476 ns |     0.32 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet      | ?             |      3,762.564 ns |     0.64 |          - | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs       | ?             |      3,992.779 ns |     0.68 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo        | ?             |      5,842.457 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT1_Arch          | ?             |      8,584.237 ns |     1.47 |    12000 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs       | ?             |     38,815.317 ns |     6.64 |    86400 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam      | ?             |      5,129.007 ns |     0.67 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs    | ?             |      7,279.134 ns |     0.94 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh        | ?             |      7,586.708 ns |     0.98 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo        | ?             |      7,711.505 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT5_Arch          | ?             |     23,551.362 ns |     3.05 |     8800 B | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs       | ?             |     29,931.074 ns |     3.88 |          - | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet      | ?             |     37,139.179 ns |     4.82 |          - | 
| fennecs           | AddRemoveComponentsT5_Fennecs       | ?             |    305,533.345 ns |    39.62 |   620800 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 1             |      5,897.404 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 1             |     10,634.237 ns |     1.80 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 1             |     15,740.775 ns |     2.67 |          - | 
| Arch              | AddRemoveLinks_Arch                 | 1             |     70,148.888 ns |    11.89 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 1             |     94,730.415 ns |    16.06 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 100           |    962,455.103 ns |     0.78 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 100           |  1,236,055.620 ns |     1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch                 | 100           |  4,308,102.018 ns |     3.49 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 100           |  4,680,562.586 ns |     3.79 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 100           | 71,385,087.036 ns |    57.73 | 93124892 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 1             |      3,747.582 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 1             |     11,960.802 ns |     3.19 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 1             |     23,433.862 ns |     6.25 |          - | 
| Arch              | AddRemoveRelations_Arch             | 1             |     45,446.515 ns |    12.13 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 1             |     96,042.487 ns |    25.63 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 10            |     47,234.524 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 10            |    158,712.116 ns |     3.36 |          - | 
| Arch              | AddRemoveRelations_Arch             | 10            |    202,462.156 ns |     4.29 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 10            |    282,339.738 ns |     5.98 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 10            |  1,560,338.818 ns |    33.03 |  2540001 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo       | ?             |     30,259.805 ns |     1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet     | ?             |     94,958.596 ns |     3.14 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs      | ?             |    190,060.927 ns |     6.28 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch         | ?             |    432,550.445 ns |    14.30 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs      | ?             |    936,249.569 ns |    30.94 |  1800001 B | 
|                   |                                     |               |                   |          |            | 
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?             |      5,037.601 ns |     0.58 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?             |      8,619.076 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?             |     12,842.928 ns |     1.49 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?             |     14,358.879 ns |     1.67 |          - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?             |     16,889.462 ns |     2.01 |          - | 
| Myriad            | CommandBufferAddRemoveT2_Myriad     | ?             |     27,602.945 ns |     3.20 |          - | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?             |     48,246.568 ns |     5.60 |     4800 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?             |      2,519.122 ns |     0.31 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?             |      4,466.644 ns |     0.56 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?             |      8,022.354 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?             |     11,329.922 ns |     1.41 |          - | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo               | ?             |    394,972.000 ns |     1.00 |  3454080 B | 
| TinyEcs           | CreateEntityT1_TinyEcs              | ?             |    950,830.214 ns |     2.41 |  6119312 B | 
| fennecs           | CreateEntityT1_Fennecs              | ?             |  1,056,386.643 ns |     2.68 |  6815624 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet             | ?             |  1,327,682.444 ns |     3.35 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam             | ?             |  1,954,429.154 ns |     4.95 |  7322344 B | 
| Arch              | CreateEntityT1_Arch                 | ?             |  2,117,530.900 ns |     5.40 |  3255576 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs           | ?             |  6,544,696.452 ns |    16.79 | 11591808 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh               | ?             | 42,971,583.571 ns |   108.67 | 42293640 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo               | ?             |    440,631.077 ns |     1.00 |  4506960 B | 
| fennecs           | CreateEntityT3_Fennecs              | ?             |    972,880.929 ns |     2.21 |  7866912 B | 
| TinyEcs           | CreateEntityT3_TinyEcs              | ?             |    982,329.923 ns |     2.23 |  6942912 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet             | ?             |  1,519,723.267 ns |     3.45 |      736 B | 
| Arch              | CreateEntityT3_Arch                 | ?             |  2,406,022.516 ns |     5.45 |  4043272 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam             | ?             |  3,545,504.167 ns |     8.08 | 11517616 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs           | ?             |  9,956,303.680 ns |    22.66 | 19984720 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh               | ?             | 29,576,964.214 ns |    67.19 | 49285544 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs              | ?             |         72.595 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                  | ?             |        231.860 ns |     1.00 |     3952 B | 
| Myriad            | CreateWorld_Myriad                  | ?             |        803.827 ns |     3.47 |    19776 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam                | ?             |      1,455.561 ns |     6.28 |    58944 B | 
| Arch              | CreateWorld_Arch                    | ?             |      3,375.623 ns |    14.56 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                  | ?             |      4,282.181 ns |    18.47 |     5056 B | 
| fennecs           | CreateWorld_Fennecs                 | ?             |     21,585.682 ns |    93.06 |   169364 B | 
| TinyEcs           | CreateWorld_TinyEcs                 | ?             |     51,987.624 ns |   224.22 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet                | ?             |    973,466.227 ns | 4,196.87 |     1009 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo                 | ?             |  1,642,410.357 ns |     1.00 |      736 B | 
| Flecs.NET         | DeleteEntity_FlecsNet               | ?             |  1,992,845.846 ns |     1.21 |      736 B | 
| Arch              | DeleteEntity_Arch                   | ?             |  2,782,224.615 ns |     1.69 |  2096360 B | 
| TinyEcs           | DeleteEntity_TinyEcs                | ?             |  3,328,400.400 ns |     2.03 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs             | ?             |  3,803,380.692 ns |     2.30 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam               | ?             |  4,936,231.410 ns |     2.97 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs                | ?             |  5,801,557.857 ns |     3.54 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh                 | ?             |  8,815,024.143 ns |     5.38 |  1398360 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam         | ?             |         65.215 ns |     0.32 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs       | ?             |        109.152 ns |     0.53 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo           | ?             |        205.305 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch             | ?             |        292.638 ns |     1.43 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh           | ?             |        329.442 ns |     1.60 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet         | ?             |        582.090 ns |     2.84 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs          | ?             |        726.850 ns |     3.54 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs          | ?             |      2,431.223 ns |    11.84 |          - | 
|                   |                                     |               |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmentedT1_Morpeh            | ?             |          4.590 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmentedT1_Default           | ?             |         12.838 ns |     0.33 |          - | 
| Leopotam.EcsLite  | QueryFragmentedT1_Leopotam          | ?             |         24.756 ns |     0.64 |          - | 
| Friflo.Engine.ECS | QueryFragmentedT1_Friflo            | ?             |         38.854 ns |     1.00 |          - | 
| Myriad            | QueryFragmentedT1_Myriad            | ?             |         93.624 ns |     2.41 |          - | 
| TinyEcs           | QueryFragmentedT1_TinyEcs           | ?             |        129.520 ns |     3.33 |          - | 
| Arch              | QueryFragmentedT1_Arch              | ?             |        227.044 ns |     5.84 |          - | 
| Flecs.NET         | QueryFragmentedT1_FlecsNet          | ?             |        320.747 ns |     8.26 |          - | 
| fennecs           | QueryFragmentedT1_Fennecs           | ?             |      1,517.720 ns |    39.06 |      120 B | 
|                   |                                     |               |                   |          |            | 
| Myriad            | QueryT1_Myriad                      | ?             |                NA |        ? |         NA | 
| DefaultEcs        | QueryT1_Default                     | ?             |         45.000 ns |     0.98 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                      | ?             |         45.743 ns |     1.00 |          - | 
| TinyEcs           | QueryT1_TinyEcs                     | ?             |         67.189 ns |     1.47 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                    | ?             |         76.537 ns |     1.67 |          - | 
| Arch              | QueryT1_Arch                        | ?             |        123.244 ns |     2.69 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                    | ?             |        145.740 ns |     3.19 |          - | 
| fennecs           | QueryT1_Fennecs                     | ?             |        197.153 ns |     4.31 |       88 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                      | ?             |        310.476 ns |     6.79 |          - | 
|                   |                                     |               |                   |          |            | 
| Myriad            | QueryT5_Myriad                      | ?             |                NA |        ? |         NA | 
| Friflo.Engine.ECS | QueryT5_Friflo                      | ?             |        110.619 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                     | ?             |        118.945 ns |     1.08 |          - | 
| Arch              | QueryT5_Arch                        | ?             |        198.316 ns |     1.80 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                    | ?             |        200.783 ns |     1.82 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs                  | ?             |        271.859 ns |     2.46 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                    | ?             |        337.756 ns |     3.05 |          - | 
| fennecs           | QueryT5_Fennecs                     | ?             |        441.563 ns |     4.00 |       88 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                      | ?             |        783.863 ns |     7.09 |          - | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | SearchComponentField_Friflo         | ?             |      4,672.353 ns |     1.00 |          - | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | SearchRange_Friflo                  | ?             |  1,397,424.938 ns |     1.00 |   560001 B | 

Benchmarks with issues:
  QueryT1_Myriad.Run: DefaultJob
  QueryT5_Myriad.Run: DefaultJob
