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
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?             |      5,002.902 ns |     0.59 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?             |      8,538.175 ns |     1.00 |          - | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?             |      9,829.185 ns |     1.15 |          - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?             |     13,081.939 ns |     1.53 |     4800 B | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?             |     16,153.339 ns |     1.89 |          - | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?             |     46,801.663 ns |     5.48 |     4800 B | 
