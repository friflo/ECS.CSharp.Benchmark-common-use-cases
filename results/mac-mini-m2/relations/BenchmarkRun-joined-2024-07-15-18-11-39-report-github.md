```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=ShortRun  InvocationCount=Default  
IterationCount=3  LaunchCount=1  UnrollFactor=16  
WarmupCount=3  

```
| Namespace         | Type                        | RelationCount | Mean          | Ratio | Allocated  | 
|------------------ |---------------------------- |-------------- |--------------:|------:|-----------:|-
| Friflo.Engine.ECS | AddRemoveLinks_Friflo       | 1             |      5.121 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet     | 1             |     10.288 μs |  2.01 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs      | 1             |     28.474 μs |  5.56 |    22400 B | 
| fennecs           | AddRemoveLinks_Fennecs      | 1             |     92.031 μs | 17.97 |   180000 B | 
|                   |                             |               |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet     | 100           |    951.067 μs |  0.80 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo       | 100           |  1,196.263 μs |  1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs      | 100           |  8,942.207 μs |  7.48 | 18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs      | 100           | 71,197.121 μs | 59.52 | 93124905 B | 
|                   |                             |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo   | 1             |      3.086 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet | 1             |      4.912 μs |  1.59 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs  | 1             |     32.772 μs | 10.62 |    53600 B | 
| fennecs           | AddRemoveRelations_Fennecs  | 1             |     39.935 μs | 12.94 |    86400 B | 
|                   |                             |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo   | 10            |     49.105 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet | 10            |    107.566 μs |  2.19 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs  | 10            |    448.744 μs |  9.14 |   694400 B | 
| fennecs           | AddRemoveRelations_Fennecs  | 10            |    979.254 μs | 19.94 |  1704801 B | 
