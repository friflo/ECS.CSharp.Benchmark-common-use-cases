```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=DefaultJob  InvocationCount=Default  
IterationCount=Default  LaunchCount=Default  UnrollFactor=16  
WarmupCount=Default  

```
| Namespace         | Type                        | RelationCount | Mean          | Ratio | Allocated  | 
|------------------ |---------------------------- |-------------- |--------------:|------:|-----------:|
| Friflo.Engine.ECS | AddRemoveLinks_Friflo       | 1             |      5.131 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet     | 1             |     10.414 μs |  2.03 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs      | 1             |     28.928 μs |  5.64 |    22400 B | 
| Arch              | AddRemoveLinks_Arch         | 1             |     70.704 μs | 13.78 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs      | 1             |     92.526 μs | 18.03 |   180000 B | 
|                   |                             |               |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet     | 100           |    966.370 μs |  0.80 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo       | 100           |  1,202.795 μs |  1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch         | 100           |  4,198.957 μs |  3.49 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs      | 100           |  9,039.655 μs |  7.52 | 18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs      | 100           | 70,773.543 μs | 58.86 | 93124892 B | 
|                   |                             |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo   | 1             |      3.092 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet | 1             |     12.242 μs |  3.96 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs  | 1             |     47.587 μs | 15.39 |    71200 B | 
| Arch              | AddRemoveRelations_Arch     | 1             |     48.630 μs | 15.73 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs  | 1             |     95.908 μs | 31.02 |   180000 B | 
|                   |                             |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo   | 10            |     48.461 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet | 10            |    156.169 μs |  3.22 |          - | 
| Arch              | AddRemoveRelations_Arch     | 10            |    203.380 μs |  4.20 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs  | 10            |    587.435 μs | 12.12 |   856001 B | 
| fennecs           | AddRemoveRelations_Fennecs  | 10            |  1,582.738 μs | 32.66 |  2573601 B | 
