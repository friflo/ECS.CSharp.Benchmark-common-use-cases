```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-QCZYEK : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated   | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|------------:|
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 1             |       5,079.46 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 1             |      10,547.73 ns |     2.08 |           - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 1             |      29,066.88 ns |     5.72 |     22400 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 1             |      94,018.67 ns |    18.51 |    180000 B | 
|                   |                                     |               |                   |          |             | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 100           |     946,965.33 ns |     0.81 |         1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 100           |   1,174,364.42 ns |     1.00 |         1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 100           |   9,017,758.64 ns |     7.68 |  18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 100           |  71,485,885.42 ns |    60.87 |  93124892 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 1             |       3,083.93 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 1             |       4,894.79 ns |     1.59 |           - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 1             |      32,151.28 ns |    10.43 |     53600 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 1             |      40,777.41 ns |    13.22 |     86400 B | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 10            |      48,452.44 ns |     1.00 |           - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 10            |     106,787.94 ns |     2.20 |           - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 10            |     445,950.23 ns |     9.20 |    694400 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 10            |     977,793.31 ns |    20.18 |   1704801 B | 
