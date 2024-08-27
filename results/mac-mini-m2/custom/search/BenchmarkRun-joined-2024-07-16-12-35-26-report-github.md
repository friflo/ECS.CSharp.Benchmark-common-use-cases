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
| Friflo.Engine.ECS | SearchComponentField_Friflo         | ?             |       4,875.02 ns |     1.00 |           - | 
|                   |                                     |               |                   |          |             | 
| Friflo.Engine.ECS | SearchRange_Friflo                  | ?             |   1,343,502.49 ns |     1.00 |    560001 B | 
