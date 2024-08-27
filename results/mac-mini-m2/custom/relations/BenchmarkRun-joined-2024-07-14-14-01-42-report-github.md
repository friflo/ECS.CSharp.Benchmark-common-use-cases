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
| Namespace         | Type                    | TargetCount | Mean          | Ratio | Allocated  | 
|------------------ |------------------------ |------------ |--------------:|------:|-----------:|
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 1           |      5.217 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 1           |     10.345 μs |  1.98 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 1           |     25.764 μs |  4.94 |    22400 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 1           |     90.356 μs | 17.32 |   180000 B | 
|                   |                         |             |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 100         |    958.783 μs |  0.81 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 100         |  1,191.541 μs |  1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 100         |  8,471.446 μs |  7.11 | 18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 100         | 78,162.343 μs | 65.66 | 93124905 B | 
