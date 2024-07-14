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
| Namespace         | Type                                | Mean      | Ratio | Allocated | 
|------------------ |------------------------------------ |----------:|------:|----------:|
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     |  4.989 μs |  0.59 |         - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     |  8.497 μs |  1.00 |         - | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   |  9.811 μs |  1.15 |         - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | 16.520 μs |  1.94 |         - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | 40.641 μs |  4.78 |   46928 B | 
| Arch              | CommandBufferAddRemoveT2_Arch       | 51.464 μs |  6.06 |    4800 B | 
