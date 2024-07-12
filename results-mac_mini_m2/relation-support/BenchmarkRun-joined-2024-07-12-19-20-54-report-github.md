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
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 1           |      5.138 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 1           |      9.992 μs |  1.94 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 1           |     25.800 μs |  5.02 |    22400 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 1           |     93.045 μs | 18.11 |   180000 B | 
|                   |                         |             |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 100         |    936.396 μs |  0.80 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 100         |  1,171.335 μs |  1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 100         |  8,680.643 μs |  7.41 | 18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 100         | 71,750.446 μs | 61.26 | 93124905 B | 
