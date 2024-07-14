```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

Method=Run  Job=ShortRun  InvocationCount=Default  
IterationCount=3  LaunchCount=1  UnrollFactor=16  
WarmupCount=3  

```
| Type                        | Mean         | Ratio | Allocated | 
|---------------------------- |-------------:|------:|----------:|
| SearchComponentField_Friflo |     4.714 μs |  1.00 |         - | 
|                             |              |       |           | 
| SearchRange_Friflo          | 1,328.126 μs |  1.00 |  560001 B | 
