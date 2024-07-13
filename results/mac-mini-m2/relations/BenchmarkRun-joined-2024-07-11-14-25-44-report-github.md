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
| Namespace         | Type                   | TargetCount | Mean       | Ratio | Allocated   | 
|------------------ |----------------------- |------------ |-----------:|------:|------------:|
| Friflo.Engine.ECS | AddRemoveLinks_Friflo  | 1           |      51 μs |  1.00 |           - | 
| fennecs           | AddRemoveLinks_Fennecs | 1           |     938 μs | 18.39 |   1800001 B | 
|                   |                        |             |            |       |             | 
| Friflo.Engine.ECS | AddRemoveLinks_Friflo  | 100         |  11,890 μs |  1.00 |        12 B | 
| fennecs           | AddRemoveLinks_Fennecs | 100         | 718,838 μs | 60.46 | 931248736 B | 
