```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-QCZYEK : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated   | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|------------:|
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?             |       5,064.27 ns |     0.58 |           - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?             |       8,736.44 ns |     1.00 |           - | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?             |       9,844.70 ns |     1.13 |           - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?             |      16,674.18 ns |     1.91 |           - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?             |      29,329.31 ns |     3.36 |     20800 B | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?             |      48,425.98 ns |     5.54 |      4800 B | 
