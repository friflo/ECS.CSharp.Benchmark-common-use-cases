```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-UGKIQF : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated  | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam      | ?             |        971.990 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs    | ?             |      1,445.134 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh        | ?             |      1,837.006 ns |     0.32 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet      | ?             |      2,918.117 ns |     0.51 |          - | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs       | ?             |      3,974.441 ns |     0.70 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo        | ?             |      5,686.199 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT1_Arch          | ?             |      8,395.015 ns |     1.48 |    12000 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs       | ?             |     38,885.417 ns |     6.84 |    86400 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam      | ?             |      5,142.330 ns |     0.66 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs    | ?             |      7,341.234 ns |     0.95 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh        | ?             |      7,660.221 ns |     0.99 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo        | ?             |      7,738.265 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT5_Arch          | ?             |     22,302.206 ns |     2.88 |     8800 B | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs       | ?             |     30,544.500 ns |     3.95 |          - | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet      | ?             |     31,677.078 ns |     4.09 |          - | 
| fennecs           | AddRemoveComponentsT5_Fennecs       | ?             |    303,744.416 ns |    39.25 |   620800 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo               | ?             |    398,502.400 ns |     1.00 |  3454080 B | 
| fennecs           | CreateEntityT1_Fennecs              | ?             |    860,255.643 ns |     2.16 |  6815576 B | 
| TinyEcs           | CreateEntityT1_TinyEcs              | ?             |    954,571.571 ns |     2.39 |  6119312 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet             | ?             |  1,348,831.829 ns |     3.36 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam             | ?             |  1,985,066.333 ns |     4.98 |  7322344 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs           | ?             |  6,542,680.962 ns |    16.39 | 11592432 B | 
| Arch              | CreateEntityT1_Arch                 | ?             | 10,317,988.667 ns |    25.90 |  3255040 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh               | ?             | 42,607,448.385 ns |   106.71 | 42293640 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo               | ?             |    452,133.350 ns |     1.00 |  4506960 B | 
| fennecs           | CreateEntityT3_Fennecs              | ?             |    931,711.154 ns |     2.06 |  7866864 B | 
| TinyEcs           | CreateEntityT3_TinyEcs              | ?             |    989,726.286 ns |     2.18 |  6942912 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet             | ?             |  1,499,024.172 ns |     3.32 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam             | ?             |  2,569,402.143 ns |     5.66 | 11517616 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs           | ?             |  5,919,036.467 ns |    13.04 | 19984528 B | 
| Arch              | CreateEntityT3_Arch                 | ?             | 10,572,175.929 ns |    23.30 |  4042736 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh               | ?             | 29,225,251.654 ns |    64.62 | 49285544 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs              | ?             |         73.810 ns |     0.35 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo                  | ?             |        212.289 ns |     1.00 |     3592 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam                | ?             |      1,447.130 ns |     6.82 |    58944 B | 
| Arch              | CreateWorld_Arch                    | ?             |      3,367.148 ns |    15.86 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh                  | ?             |      4,297.655 ns |    20.25 |     5056 B | 
| fennecs           | CreateWorld_Fennecs                 | ?             |     15,205.422 ns |    71.63 |   169796 B | 
| TinyEcs           | CreateWorld_TinyEcs                 | ?             |     50,746.745 ns |   238.96 |  1312184 B | 
| Flecs.NET         | CreateWorld_FlecsNet                | ?             |    967,689.680 ns | 4,556.67 |     1009 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo                 | ?             |  1,599,785.000 ns |     1.00 |  3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet               | ?             |  1,986,746.250 ns |     1.24 |      736 B | 
| Arch              | DeleteEntity_Arch                   | ?             |  2,649,192.000 ns |     1.65 |     3088 B | 
| TinyEcs           | DeleteEntity_TinyEcs                | ?             |  3,308,196.400 ns |     2.09 |     1480 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs             | ?             |  3,713,867.814 ns |     2.36 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam               | ?             |  4,718,733.919 ns |     2.96 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs                | ?             |  5,749,906.962 ns |     3.60 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh                 | ?             |  9,084,572.519 ns |     5.57 |  1398360 B | 
|                   |                                     |               |                   |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam         | ?             |         65.231 ns |     0.43 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs       | ?             |        111.755 ns |     0.74 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo           | ?             |        151.254 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch             | ?             |        282.803 ns |     1.87 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh           | ?             |        328.107 ns |     2.17 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet         | ?             |        581.852 ns |     3.85 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs          | ?             |        716.205 ns |     4.74 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs          | ?             |      2,368.102 ns |    15.66 |          - | 
|                   |                                     |               |                   |          |            | 
| Scellecs.Morpeh   | QueryFragmentedT1_Morpeh            | ?             |          4.485 ns |     0.11 |          - | 
| DefaultEcs        | QueryFragmentedT1_Default           | ?             |         12.623 ns |     0.32 |          - | 
| Leopotam.EcsLite  | QueryFragmentedT1_Leopotam          | ?             |         24.758 ns |     0.62 |          - | 
| Friflo.Engine.ECS | QueryFragmentedT1_Friflo            | ?             |         39.927 ns |     1.00 |          - | 
| TinyEcs           | QueryFragmentedT1_TinyEcs           | ?             |        130.312 ns |     3.26 |          - | 
| Arch              | QueryFragmentedT1_Arch              | ?             |        229.079 ns |     5.74 |          - | 
| Flecs.NET         | QueryFragmentedT1_FlecsNet          | ?             |        319.636 ns |     8.01 |          - | 
| fennecs           | QueryFragmentedT1_Fennecs           | ?             |      1,442.803 ns |    36.14 |       40 B | 
|                   |                                     |               |                   |          |            | 
| DefaultEcs        | QueryT1_Default                     | ?             |         44.736 ns |     0.95 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                      | ?             |         47.339 ns |     1.00 |          - | 
| TinyEcs           | QueryT1_TinyEcs                     | ?             |         65.658 ns |     1.39 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                    | ?             |         76.443 ns |     1.61 |          - | 
| Arch              | QueryT1_Arch                        | ?             |        119.413 ns |     2.52 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                    | ?             |        142.138 ns |     3.00 |          - | 
| fennecs           | QueryT1_Fennecs                     | ?             |        166.640 ns |     3.52 |       40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                      | ?             |        308.905 ns |     6.53 |          - | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | QueryT5_Friflo                      | ?             |        109.311 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                     | ?             |        122.910 ns |     1.12 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                    | ?             |        197.486 ns |     1.80 |          - | 
| Arch              | QueryT5_Arch                        | ?             |        198.859 ns |     1.82 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs                  | ?             |        270.893 ns |     2.48 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                    | ?             |        344.386 ns |     3.15 |          - | 
| fennecs           | QueryT5_Fennecs                     | ?             |        417.778 ns |     3.84 |       40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                      | ?             |        787.497 ns |     7.20 |          - | 
