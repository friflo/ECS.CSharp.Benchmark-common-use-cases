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
| DefaultEcs        | ComponentEvents_DefaultEcs          | ?             |       2,602.10 ns |     0.35 |           - | 
| Friflo.Engine.ECS | ComponentEvents_Friflo              | ?             |       7,480.85 ns |     1.00 |           - | 
| Flecs.NET         | ComponentEvents_FlecsNet            | ?             |      10,419.53 ns |     1.39 |           - | 
| TinyEcs           | ComponentEvents_TinyEcs             | ?             |      13,781.00 ns |     1.84 |      6400 B | 
