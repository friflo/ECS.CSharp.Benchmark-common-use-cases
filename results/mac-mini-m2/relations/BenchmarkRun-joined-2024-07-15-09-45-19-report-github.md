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
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 1           |      5.123 μs |  1.00 |          - | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 1           |     10.292 μs |  2.01 |          - | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 1           |     28.581 μs |  5.58 |    22400 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 1           |     92.580 μs | 18.07 |   180000 B | 
|                   |                         |             |               |       |            | 
| Flecs.NET         | AddRemoveLinks_FlecsNet | 100         |    947.199 μs |  0.82 |        1 B | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo   | 100         |  1,158.830 μs |  1.00 |        1 B | 
| TinyEcs           | AddRemoveLinks_TinyEcs  | 100         |  8,776.224 μs |  7.57 | 18080012 B | 
| fennecs           | AddRemoveLinks_Fennecs  | 100         | 70,384.219 μs | 60.74 | 93124892 B | 
