```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  Job-HQFOUT : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  
WarmupCount=Default  

```
| Namespace         | Type                                | RelationCount | Mean              | Ratio    | Allocated  | 
|------------------ |------------------------------------ |-------------- |------------------:|---------:|-----------:|
| Scellecs.Morpeh   | CommandBufferAddRemoveT2_Morpeh     | ?             |      5,121.168 ns |     0.60 |          - | 
| Friflo.Engine.ECS | CommandBufferAddRemoveT2_Friflo     | ?             |      8,490.131 ns |     1.00 |          - | 
| TinyEcs           | CommandBufferAddRemoveT2_TinyEcs    | ?             |     12,959.426 ns |     1.53 |     4800 B | 
| Flecs.NET         | CommandBufferAddRemoveT2_FlecsNet   | ?             |     14,399.755 ns |     1.70 |          - | 
| DefaultEcs        | CommandBufferAddRemoveT2_DefaultEcs | ?             |     16,476.300 ns |     1.94 |          - | 
| Arch              | CommandBufferAddRemoveT2_Arch       | ?             |     48,222.287 ns |     5.68 |     4800 B | 
