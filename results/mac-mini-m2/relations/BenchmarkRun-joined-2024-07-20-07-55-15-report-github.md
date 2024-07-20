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
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 1             |      5,158.115 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 1             |     10,405.861 ns |     2.02 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 1             |     15,944.422 ns |     3.09 |          - | 
| Arch              | AddRemoveLinks_Arch                 | 1             |     67,361.194 ns |    13.06 |    36800 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 1             |     93,101.587 ns |    18.05 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet             | 100           |    958,910.550 ns |     0.82 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo               | 100           |  1,172,994.547 ns |     1.00 |        1 B | 
| Arch              | AddRemoveLinks_Arch                 | 100           |  4,185,699.719 ns |     3.57 |  2180006 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs              | 100           |  4,206,844.402 ns |     3.59 |        8 B | 
| fennecs           | AddRemoveLinks_Fennecs              | 100           | 71,216,263.476 ns |    60.71 | 93124905 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 1             |      3,113.553 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 1             |     11,897.898 ns |     3.82 |          - | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 1             |     23,450.462 ns |     7.53 |          - | 
| Arch              | AddRemoveRelations_Arch             | 1             |     43,913.855 ns |    14.10 |    36800 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 1             |     96,208.373 ns |    30.90 |   180000 B | 
|                   |                                     |               |                   |          |            | 
| Friflo.Engine.ECS | AddRemoveRelations_Friflo           | 10            |     47,820.866 ns |     1.00 |          - | 
| Flecs.NET         | AddRemoveRelations_FlecsNet         | 10            |    155,591.457 ns |     3.25 |          - | 
| Arch              | AddRemoveRelations_Arch             | 10            |    198,107.264 ns |     4.14 |   240800 B | 
| TinyEcs           | AddRemoveRelations_TinyEcs          | 10            |    283,759.688 ns |     5.93 |        1 B | 
| fennecs           | AddRemoveRelations_Fennecs          | 10            |  1,564,173.810 ns |    32.71 |  2568001 B | 
