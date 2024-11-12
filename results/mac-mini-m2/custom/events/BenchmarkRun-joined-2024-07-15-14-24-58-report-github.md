```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=ShortRun  InvocationCount=Default  
IterationCount=3  LaunchCount=1  UnrollFactor=16  
WarmupCount=3  Alloc Ratio=NA  

```
| Namespace         | Type                       | Mean      | Ratio | Allocated | 
|------------------ |--------------------------- |----------:|------:|----------:|
| DefaultEcs        | ComponentEvents_DefaultEcs |  2.567 μs |  0.34 |         - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo     |  7.577 μs |  1.00 |         - | 
| Flecs.NET         | ComponentEvents_FlecsNet   | 10.378 μs |  1.37 |         - | 
| TinyEcs           | ComponentEvents_TinyEcs    | 13.834 μs |  1.83 |    6400 B | 