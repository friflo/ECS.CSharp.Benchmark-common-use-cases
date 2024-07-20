```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-HQFOUT : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated  | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam      | ?             |        976.432 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs    | ?             |      1,449.227 ns |     0.26 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh        | ?             |      1,826.233 ns |     0.32 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet      | ?             |      3,755.583 ns |     0.67 |          - | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs       | ?             |      3,948.969 ns |     0.70 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo        | ?             |      5,645.639 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT1_Arch          | ?             |      8,557.163 ns |     1.52 |    12000 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs       | ?             |     38,802.742 ns |     6.87 |    86400 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam      | ?             |      5,148.740 ns |     0.68 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs    | ?             |      7,229.812 ns |     0.95 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo        | ?             |      7,598.536 ns |     1.00 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh        | ?             |      7,696.852 ns |     1.01 |          - | 
| Arch              | AddRemoveComponentsT5_Arch          | ?             |     22,557.777 ns |     2.97 |     8800 B | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs       | ?             |     29,987.274 ns |     3.95 |          - | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet      | ?             |     35,145.788 ns |     4.63 |          - | 
| fennecs           | AddRemoveComponentsT5_Fennecs       | ?             |    306,849.204 ns |    40.39 |   620800 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo               | ?             |    395,229.571 ns |     1.00 |  3454080 B | 
| fennecs           | CreateEntityT1_Fennecs              | ?             |    856,106.857 ns |     2.17 |  6815576 B | 
| TinyEcs           | CreateEntityT1_TinyEcs              | ?             |    955,280.875 ns |     2.42 |  6119312 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet             | ?             |  1,341,023.684 ns |     3.39 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam             | ?             |  1,954,243.231 ns |     4.95 |  7322344 B | 
| Arch              | CreateEntityT1_Arch                 | ?             |  2,116,586.814 ns |     5.37 |  3255040 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs           | ?             |  6,606,963.929 ns |    16.72 | 11592440 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh               | ?             | 42,806,285.000 ns |   108.53 | 42293688 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo               | ?             |    468,328.642 ns |     1.00 |  4506960 B | 
| fennecs           | CreateEntityT3_Fennecs              | ?             |    937,038.231 ns |     1.84 |  7866864 B | 
| TinyEcs           | CreateEntityT3_TinyEcs              | ?             |    986,724.000 ns |     1.93 |  6942912 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet             | ?             |  1,472,139.350 ns |     2.91 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam             | ?             |  3,504,630.200 ns |     6.87 | 11517616 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs           | ?             |  5,709,662.040 ns |    11.47 | 19984552 B | 
| Arch              | CreateEntityT3_Arch                 | ?             | 10,641,060.733 ns |    20.86 |  4042736 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh               | ?             | 29,669,684.269 ns |    58.26 | 49285544 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs              | ?             |         72.598 ns |     0.31 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                  | ?             |        236.910 ns |     1.00 |     3992 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam                | ?             |      1,445.381 ns |     6.10 |    58944 B | 
| Arch              | CreateWorld_Arch                    | ?             |      3,391.405 ns |    14.32 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                  | ?             |      4,311.495 ns |    18.20 |     5056 B | 
| fennecs           | CreateWorld_Fennecs                 | ?             |     15,311.501 ns |    64.63 |   169796 B | 
| TinyEcs           | CreateWorld_TinyEcs                 | ?             |     51,827.521 ns |   218.77 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet                | ?             |    994,502.472 ns | 4,198.49 |     1009 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo                 | ?             |  1,609,060.462 ns |     1.00 |  3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet               | ?             |  1,989,204.929 ns |     1.24 |      736 B | 
| Arch              | DeleteEntity_Arch                   | ?             |  2,695,781.692 ns |     1.68 |     3088 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs             | ?             |  3,706,715.351 ns |     2.34 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam               | ?             |  4,666,441.571 ns |     2.90 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs                | ?             |  5,698,660.571 ns |     3.54 |  4366912 B | 
| TinyEcs           | DeleteEntity_TinyEcs                | ?             |  8,313,336.857 ns |     5.17 |     1480 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh                 | ?             |  8,696,239.375 ns |     5.42 |  1398360 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam         | ?             |         65.243 ns |     0.43 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs       | ?             |        111.619 ns |     0.74 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo           | ?             |        151.404 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch             | ?             |        288.744 ns |     1.91 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh           | ?             |        325.358 ns |     2.15 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet         | ?             |        582.056 ns |     3.84 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs          | ?             |        717.130 ns |     4.74 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs          | ?             |      2,354.759 ns |    15.55 |          - | 
|                   |                                     |               |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmentedT1_Morpeh            | ?             |          4.587 ns |     0.12 |          - | 
| DefaultEcs        | QueryFragmentedT1_Default           | ?             |         12.839 ns |     0.32 |          - | 
| Leopotam.EcsLite  | QueryFragmentedT1_Leopotam          | ?             |         24.783 ns |     0.62 |          - | 
| Friflo.Engine.ECS | QueryFragmentedT1_Friflo            | ?             |         39.763 ns |     1.00 |          - | 
| TinyEcs           | QueryFragmentedT1_TinyEcs           | ?             |        130.555 ns |     3.28 |          - | 
| Arch              | QueryFragmentedT1_Arch              | ?             |        232.599 ns |     5.85 |          - | 
| Flecs.NET         | QueryFragmentedT1_FlecsNet          | ?             |        325.041 ns |     8.17 |          - | 
| fennecs           | QueryFragmentedT1_Fennecs           | ?             |      1,491.940 ns |    37.51 |       40 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | QueryT1_Default                     | ?             |         45.009 ns |     0.93 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                      | ?             |         48.411 ns |     1.00 |          - | 
| TinyEcs           | QueryT1_TinyEcs                     | ?             |         66.418 ns |     1.37 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                    | ?             |         76.634 ns |     1.58 |          - | 
| Arch              | QueryT1_Arch                        | ?             |        120.481 ns |     2.49 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                    | ?             |        143.297 ns |     2.96 |          - | 
| fennecs           | QueryT1_Fennecs                     | ?             |        176.342 ns |     3.64 |       40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                      | ?             |        313.029 ns |     6.47 |          - | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | QueryT5_Friflo                      | ?             |        112.136 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                     | ?             |        118.721 ns |     1.06 |          - | 
| Arch              | QueryT5_Arch                        | ?             |        198.465 ns |     1.77 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                    | ?             |        200.850 ns |     1.79 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs                  | ?             |        271.819 ns |     2.42 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                    | ?             |        336.674 ns |     3.00 |          - | 
| fennecs           | QueryT5_Fennecs                     | ?             |        405.841 ns |     3.62 |       40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                      | ?             |        790.498 ns |     7.05 |          - | 
