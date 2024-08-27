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
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 1             |      5,428.089 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 1             |     10,567.567 ns |     1.95 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 1             |     15,696.415 ns |     2.89 |          - | 
| Arch              | AddRemoveLinks_Arch                 | 1             |     72,352.899 ns |    13.33 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 1             |     94,680.991 ns |    17.44 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 100           |    967,353.470 ns |     0.84 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 100           |  1,156,866.743 ns |     1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 100           |  3,496,924.692 ns |     3.02 |        4 B | 
| Arch              | AddRemoveLinks_Arch                 | 100           |  4,297,847.757 ns |     3.72 |  2180006 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 100           | 70,893,303.581 ns |    61.28 | 93124905 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 1             |      3,385.548 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 1             |     12,279.739 ns |     3.63 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 1             |     23,528.519 ns |     6.95 |          - | 
| Arch              | AddRemoveRelations_Arch             | 1             |     49,004.396 ns |    14.47 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 1             |     95,627.608 ns |    28.25 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 10            |     45,817.621 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 10            |    158,533.870 ns |     3.46 |          - | 
| Arch              | AddRemoveRelations_Arch             | 10            |    200,083.760 ns |     4.37 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 10            |    285,382.981 ns |     6.23 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 10            |  1,548,092.295 ns |    33.80 |  2528801 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | ChildEntitiesAddRemove_Friflo       | ?             |     37,385.854 ns |        ? |          - | 
| Flecs.NET         | ChildEntitiesAddRemove_FlecsNet     | ?             |     94,565.904 ns |        ? |          - | 
| TinyEcs           | ChildEntitiesAddRemove_TinyEcs      | ?             |    188,211.709 ns |        ? |          - | 
| Arch              | ChildEntitiesAddRemove_Arch         | ?             |    430,421.345 ns |        ? |   232801 B | 
| fennecs           | ChildEntitiesAddRemove_Fennecs      | ?             |    942,540.509 ns |        ? |  1800001 B | 
