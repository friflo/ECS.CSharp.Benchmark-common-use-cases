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
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?             |      2,582.976 ns |     0.33 |          - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?             |      4,422.520 ns |     0.57 |          - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?             |      7,749.574 ns |     1.00 |          - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?             |     10,474.904 ns |     1.35 |          - | 
