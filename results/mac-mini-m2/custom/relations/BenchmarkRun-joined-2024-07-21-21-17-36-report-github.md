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
| Namespace         | Type                            | RelationCount | Mean          | Ratio | Allocated  | 
|------------------ |-------------------------------- |-------------- |--------------:|------:|-----------:|
| Friflo.Engine.ECS | AddRemoveLinks_Friflo           | 1             |      5.410 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet         | 1             |     10.511 μs |  1.94 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs          | 1             |     15.920 μs |  2.94 |          - | 
| Arch              | AddRemoveLinks_Arch             | 1             |     71.061 μs | 13.14 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs          | 1             |     93.581 μs | 17.30 |   180000 B | 
|                   |                                 |               |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet         | 100           |    977.162 μs |  0.84 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo           | 100           |  1,164.127 μs |  1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch             | 100           |  4,267.588 μs |  3.67 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs          | 100           |  4,716.078 μs |  4.05 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs          | 100           | 71,543.598 μs | 61.46 | 93124892 B | 
|                   |                                 |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo       | 1             |      3.370 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet     | 1             |     11.904 μs |  3.53 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs      | 1             |     23.368 μs |  6.93 |          - | 
| Arch              | AddRemoveRelations_Arch         | 1             |     49.145 μs | 14.58 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs      | 1             |     96.084 μs | 28.52 |   180000 B | 
|                   |                                 |               |               |       |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo       | 10            |     45.214 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet     | 10            |    154.438 μs |  3.41 |          - | 
| Arch              | AddRemoveRelations_Arch         | 10            |    200.642 μs |  4.44 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs      | 10            |    284.536 μs |  6.29 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs      | 10            |  1,560.804 μs | 34.52 |  2568001 B | 
|                   |                                 |               |               |       |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo   | ?             |     25.113 μs |  1.00 |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet | ?             |     95.019 μs |  3.78 |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs  | ?             |    190.328 μs |  7.58 |          - | 
| Arch              | ChildEntitiesAddRemove_Arch     | ?             |    434.928 μs | 17.32 |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs  | ?             |    950.426 μs | 37.86 |  1800001 B | 
