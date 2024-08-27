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
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?             |      2,548.685 ns |     0.37 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?             |      4,414.266 ns |     0.64 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?             |      6,935.659 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?             |     11,421.612 ns |     1.65 |          - | 
