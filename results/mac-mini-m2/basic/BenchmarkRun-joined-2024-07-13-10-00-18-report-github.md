```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-EPRDTK : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  

```
| Namespace         | Type                             | Mean             | Ratio    | Allocated  | 
|------------------ |--------------------------------- |-----------------:|---------:|-----------:|
| Leopotam.EcsLite  | AddRemoveComponentsT1_Leopotam   |        994.11 ns |     0.17 |          - | 
| DefaultEcs        | AddRemoveComponentsT1_DefaultEcs |      1,520.92 ns |     0.26 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT1_Morpeh     |      1,846.78 ns |     0.31 |          - | 
| Flecs.NET         | AddRemoveComponentsT1_FlecsNet   |      2,960.96 ns |     0.50 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT1_Friflo     |      5,907.98 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT1_Arch       |      8,402.13 ns |     1.42 |    12000 B | 
| TinyEcs           | AddRemoveComponentsT1_TinyEcs    |      8,850.66 ns |     1.50 |     6400 B | 
| fennecs           | AddRemoveComponentsT1_Fennecs    |     38,003.14 ns |     6.43 |    86400 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | AddRemoveComponentsT5_Leopotam   |      5,122.72 ns |     0.63 |          - | 
| DefaultEcs        | AddRemoveComponentsT5_DefaultEcs |      7,237.34 ns |     0.89 |          - | 
| Scellecs.Morpeh   | AddRemoveComponentsT5_Morpeh     |      7,632.05 ns |     0.94 |          - | 
| Friflo.Engine.ECS | AddRemoveComponentsT5_Friflo     |      8,108.88 ns |     1.00 |          - | 
| Arch              | AddRemoveComponentsT5_Arch       |     22,514.72 ns |     2.78 |     8800 B | 
| Flecs.NET         | AddRemoveComponentsT5_FlecsNet   |     31,703.08 ns |     3.92 |          - | 
| TinyEcs           | AddRemoveComponentsT5_TinyEcs    |     71,801.55 ns |     8.88 |    64000 B | 
| fennecs           | AddRemoveComponentsT5_Fennecs    |    303,704.80 ns |    37.54 |   620800 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT1_Friflo            |    400,073.60 ns |     1.00 |  3449408 B | 
| fennecs           | CreateEntityT1_Fennecs           |  1,055,624.46 ns |     2.54 |  6815576 B | 
| Arch              | CreateEntityT1_Arch              |  1,633,623.06 ns |     4.08 |     3088 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam          |  1,822,169.07 ns |     4.41 |  7315384 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet          |  3,738,708.67 ns |     9.18 |     1152 B | 
| TinyEcs           | CreateEntityT1_TinyEcs           |  5,028,663.47 ns |    12.17 |  8020784 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs        |  9,713,514.57 ns |    23.46 | 11591808 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh            | 46,627,720.86 ns |   112.59 | 42293152 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo            |    433,928.08 ns |     1.00 |  4498032 B | 
| fennecs           | CreateEntityT3_Fennecs           |    980,368.71 ns |     2.24 |  7866864 B | 
| Arch              | CreateEntityT3_Arch              |  1,799,461.61 ns |     4.14 |     3088 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam          |  2,903,398.45 ns |     6.93 | 11498800 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs        | 10,155,157.60 ns |    23.17 | 19984720 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet          | 12,535,255.86 ns |    28.61 |     1984 B | 
| TinyEcs           | CreateEntityT3_TinyEcs           | 20,476,307.54 ns |    46.64 | 21824112 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh            | 42,418,928.29 ns |    96.81 | 49284080 B | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | CreateWorld_DefaultEcs           |         71.91 ns |     0.30 |      336 B | 
| Friflo.Engine.ECS | CreateWorld_Friflo               |        239.05 ns |     1.00 |     3576 B | 
| Leopotam.EcsLite  | CreateWorld_Leopotam             |      1,456.93 ns |     6.11 |    58944 B | 
| Arch              | CreateWorld_Arch                 |      3,377.14 ns |    14.16 |    37040 B | 
| Scellecs.Morpeh   | CreateWorld_Morpeh               |      4,295.92 ns |    18.01 |     5056 B | 
| fennecs           | CreateWorld_Fennecs              |     21,960.87 ns |    92.21 |   169820 B | 
| TinyEcs           | CreateWorld_TinyEcs              |     35,735.87 ns |   149.77 |  1087272 B | 
| Flecs.NET         | CreateWorld_FlecsNet             |    934,491.18 ns | 3,913.81 |     2381 B | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | DeleteEntity_Friflo              |  1,597,744.00 ns |     1.00 |  3122896 B | 
| Flecs.NET         | DeleteEntity_FlecsNet            |  1,822,307.93 ns |     1.14 |      736 B | 
| Arch              | DeleteEntity_Arch                |  2,723,553.29 ns |     1.70 |  2096360 B | 
| DefaultEcs        | DeleteEntity_DefaultEcs          |  3,635,286.67 ns |     2.28 |  3200736 B | 
| Leopotam.EcsLite  | DeleteEntity_Leopotam            |  4,824,839.91 ns |     3.03 |  6268768 B | 
| fennecs           | DeleteEntity_Fennecs             |  5,734,411.53 ns |     3.59 |  4366912 B | 
| Scellecs.Morpeh   | DeleteEntity_Morpeh              |  8,631,451.81 ns |     5.40 |  1398360 B | 
| TinyEcs           | DeleteEntity_TinyEcs             |  8,660,894.46 ns |     5.42 |     1144 B | 
|                   |                                  |                  |          |            | 
| Leopotam.EcsLite  | GetSetComponentsT1_Leopotam      |         65.17 ns |     0.41 |          - | 
| DefaultEcs        | GetSetComponentsT1_DefaultEcs    |        106.75 ns |     0.67 |          - | 
| Friflo.Engine.ECS | GetSetComponentsT1_Friflo        |        158.78 ns |     1.00 |          - | 
| Arch              | GetSetComponentsT1_Arch          |        285.11 ns |     1.80 |          - | 
| Scellecs.Morpeh   | GetSetComponentsT1_Morpeh        |        329.21 ns |     2.07 |          - | 
| TinyEcs           | GetSetComponentsT1_TinyEcs       |        990.94 ns |     6.24 |          - | 
| Flecs.NET         | GetSetComponentsT1_FlecsNet      |      1,043.91 ns |     6.58 |          - | 
| fennecs           | GetSetComponentsT1_Fennecs       |      2,550.89 ns |    16.08 |          - | 
|                   |                                  |                  |          |            | 
| DefaultEcs        | QueryT1_Default                  |         45.15 ns |     0.93 |          - | 
| Friflo.Engine.ECS | QueryT1_Friflo                   |         48.82 ns |     1.00 |          - | 
| Leopotam.EcsLite  | QueryT1_Leopotam                 |         76.66 ns |     1.57 |          - | 
| TinyEcs           | QueryT1_TinyEcs                  |         90.00 ns |     1.84 |          - | 
| Flecs.NET         | QueryT1_FlecsNet                 |        111.50 ns |     2.28 |          - | 
| Arch              | QueryT1_Arch                     |        119.50 ns |     2.45 |          - | 
| fennecs           | QueryT1_Fennecs                  |        173.40 ns |     3.55 |       40 B | 
| Scellecs.Morpeh   | QueryT1_Morpeh                   |        312.07 ns |     6.40 |          - | 
|                   |                                  |                  |          |            | 
| Friflo.Engine.ECS | QueryT5_Friflo                   |        111.50 ns |     1.00 |          - | 
| TinyEcs           | QueryT5_TinyEcs                  |        145.52 ns |     1.31 |          - | 
| Arch              | QueryT5_Arch                     |        195.70 ns |     1.76 |          - | 
| Flecs.NET         | QueryT5_FlecsNet                 |        248.42 ns |     2.23 |          - | 
| DefaultEcs        | QueryT5_DefaultEcs               |        268.91 ns |     2.41 |          - | 
| Leopotam.EcsLite  | QueryT5_Leopotam                 |        347.40 ns |     3.12 |          - | 
| fennecs           | QueryT5_Fennecs                  |        417.85 ns |     3.75 |       40 B | 
| Scellecs.Morpeh   | QueryT5_Morpeh                   |        785.24 ns |     7.04 |          - | 
