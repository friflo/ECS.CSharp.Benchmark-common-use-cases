```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-WWZNDF : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  

```
| Namespace         | Type                             | Mean             | Ratio    | Allocated  | 
|------------------ |--------------------------------- |-----------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |        982.72 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |      1,418.10 ns |     0.25 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |      1,847.86 ns |     0.33 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |      2,924.75 ns |     0.52 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |      5,674.17 ns |     1.00 |          - | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |      8,803.17 ns |     1.55 |     6400 B | 
| Arch              | AddRemoveComponentsT1_Arch       |      8,805.45 ns |     1.55 |    12000 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |     38,272.35 ns |     6.74 |    86400 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |      5,088.08 ns |     0.65 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |      7,219.14 ns |     0.92 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |      7,622.57 ns |     0.97 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |      7,842.38 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT5_Arch       |     24,048.26 ns |     3.07 |     8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |     31,748.90 ns |     4.05 |          - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |     71,726.69 ns |     9.15 |    64000 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    |    304,045.53 ns |    38.77 |   620800 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo            |    394,037.85 ns |     1.00 |  3449408 B | 
| fennecs           | CreateEntityT1_Fennecs           |  1,070,508.21 ns |     2.72 |  6815576 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet          |  1,320,196.94 ns |     3.42 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam          |  1,861,863.50 ns |     4.81 |  7315384 B | 
| Arch              | CreateEntityT1_Arch              |  3,166,488.84 ns |    14.54 |     3088 B | 
| TinyEcs           | CreateEntityT1_TinyEcs           |  5,089,485.43 ns |    12.92 |  8020784 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs        |  6,476,562.53 ns |    16.55 | 11591808 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh            | 64,726,371.79 ns |   164.36 | 42301064 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo            |    443,651.64 ns |     1.00 |  4498032 B | 
| fennecs           | CreateEntityT3_Fennecs           |    969,218.23 ns |     2.19 |  7866864 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet          |  1,458,465.63 ns |     3.31 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam          |  3,854,255.57 ns |     8.69 | 11498824 B | 
| Arch              | CreateEntityT3_Arch              |  5,564,185.00 ns |    12.58 |     3088 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs        |  9,972,139.85 ns |    22.76 | 19984720 B | 
| TinyEcs           | CreateEntityT3_TinyEcs           | 20,391,615.85 ns |    46.00 | 21824784 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh            | 47,878,238.27 ns |   107.58 | 49284080 B | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs           |         72.86 ns |     0.34 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |        216.65 ns |     1.00 |     3584 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |      1,454.57 ns |     6.71 |    58944 B | 
| Arch              | CreateWorld_Arch                 |      3,366.49 ns |    15.54 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |      4,319.30 ns |    19.94 |     5056 B | 
| fennecs           | CreateWorld_Fennecs              |     21,408.72 ns |    98.81 |   169820 B | 
| TinyEcs           | CreateWorld_TinyEcs              |     37,101.79 ns |   171.22 |  1087272 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |    985,381.82 ns | 4,548.31 |     1009 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |  1,602,675.50 ns |     1.00 |  3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |  2,011,145.43 ns |     1.25 |      736 B | 
| Arch              | DeleteEntity_Arch                |  2,777,989.25 ns |     1.73 |  2096360 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |  3,657,826.18 ns |     2.30 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |  4,875,899.50 ns |     3.04 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs             |  5,846,256.38 ns |     3.65 |  4366912 B | 
| TinyEcs           | DeleteEntity_TinyEcs             |  7,987,843.08 ns |     4.98 |     1144 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |  8,846,687.43 ns |     5.52 |  1398360 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |         65.17 ns |     0.43 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |        108.83 ns |     0.72 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |        151.42 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch          |        286.59 ns |     1.89 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |        333.01 ns |     2.20 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |        581.96 ns |     3.84 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |        990.91 ns |     6.54 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs       |      2,380.50 ns |    15.72 |          - | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | QueryT1_Default                  |         45.04 ns |     0.94 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |         47.75 ns |     1.00 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |         76.61 ns |     1.60 |          - | 
| TinyEcs           | QueryT1_TinyEcs                  |         90.82 ns |     1.90 |          - | 
| Arch              | QueryT1_Arch                     |        120.67 ns |     2.53 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                 |        146.63 ns |     3.07 |          - | 
| fennecs           | QueryT1_Fennecs                  |        172.97 ns |     3.62 |       40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |        314.18 ns |     6.58 |          - | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |        110.25 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                  |        145.23 ns |     1.32 |          - | 
| Arch              | QueryT5_Arch                     |        197.07 ns |     1.79 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                 |        207.38 ns |     1.88 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs               |        272.29 ns |     2.47 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |        347.86 ns |     3.16 |          - | 
| fennecs           | QueryT5_Fennecs                  |        407.41 ns |     3.70 |       40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |        791.27 ns |     7.18 |          - | 
