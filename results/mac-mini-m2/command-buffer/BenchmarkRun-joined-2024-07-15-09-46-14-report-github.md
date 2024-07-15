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
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     |  4.959 μs |  0.58 |         - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     |  8.624 μs |  1.00 |         - | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   |  9.811 μs |  1.14 |         - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | 16.284 μs |  1.89 |         - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | 29.374 μs |  3.41 |   20800 B | 
| Arch              | CommandBufferAddRemoveT2_Arch       | 46.297 μs |  5.37 |    4800 B | 
