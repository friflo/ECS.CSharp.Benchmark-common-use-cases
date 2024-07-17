```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-GFBCXZ : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=Job-GFBCXZ  InvocationCount=1  
IterationCount=Default  LaunchCount=Default  UnrollFactor=1  
WarmupCount=Default  

```
| Namespace         | Type                      | Mean        | Ratio  | Allocated  | 
|------------------ |-------------------------- |------------:|-------:|-----------:|
| Friflo.Engine.ECS | CreateEntityT1_Friflo     |    394.6 μs |   1.00 |  3454080 B | 
| fennecs           | CreateEntityT1_Fennecs    |  1,059.3 μs |   2.68 |  6815576 B | 
| Flecs.NET         | CreateEntityT1_FlecsNet   |  1,332.2 μs |   3.36 |      736 B | 
| Leopotam.EcsLite  | CreateEntityT1_Leopotam   |  1,843.4 μs |   4.72 |  7321696 B | 
| TinyEcs           | CreateEntityT1_TinyEcs    |  6,511.4 μs |  16.53 | 10118352 B | 
| DefaultEcs        | CreateEntityT1_DefaultEcs |  9,520.6 μs |  24.13 | 11591808 B | 
| Arch              | CreateEntityT1_Arch       | 10,326.8 μs |  26.15 |  3255576 B | 
| Scellecs.Morpeh   | CreateEntityT1_Morpeh     | 64,369.5 μs | 162.91 | 42301552 B | 
|                   |                           |             |        |            | 
| Friflo.Engine.ECS | CreateEntityT3_Friflo     |    468.7 μs |   1.00 |  4506960 B | 
| fennecs           | CreateEntityT3_Fennecs    |    974.7 μs |   2.02 |  7866864 B | 
| Flecs.NET         | CreateEntityT3_FlecsNet   |  1,465.3 μs |   3.06 |      736 B | 
| Arch              | CreateEntityT3_Arch       |  2,350.6 μs |   5.00 |  4043272 B | 
| Leopotam.EcsLite  | CreateEntityT3_Leopotam   |  3,156.3 μs |   6.54 | 11517736 B | 
| DefaultEcs        | CreateEntityT3_DefaultEcs | 10,207.1 μs |  21.19 | 19984720 B | 
| TinyEcs           | CreateEntityT3_TinyEcs    | 23,419.3 μs |  48.50 | 23921880 B | 
| Scellecs.Morpeh   | CreateEntityT3_Morpeh     | 47,802.6 μs |  99.27 | 49285544 B | 
