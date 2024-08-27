```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.6.1 (23G93) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-NHUOOR : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-XQXVHJ : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Type                          | Entities | Components | Relations | Mean            | Ratio | Allocated | 
|------------------------------ |--------- |----------- |---------- |----------------:|------:|----------:|
| AddRemoveComponents_Friflo    | 100      | 1          | ?         |     1,693.47 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveComponents_Friflo    | 100      | 5          | ?         |     6,079.84 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveLinks_Friflo         | 100      | ?          | 1         |     5,838.25 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveLinks_Friflo         | 100      | ?          | 100       | 1,248,006.48 ns |  1.00 |       1 B | 
|                               |          |            |           |                 |       |           | 
| AddRemoveRelations_Friflo     | 100      | ?          | 1         |     3,750.74 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveRelations_Friflo     | 100      | ?          | 100       |    46,959.60 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| ChildEntitiesAddRemove_Friflo | 100      | ?          | ?         |    25,878.38 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| CommandBufferAddRemove_Friflo | 100      | ?          | ?         |     7,085.86 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| ComponentEvents_Friflo        | 100      | ?          | ?         |     1,762.07 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| CreateBulk_Friflo             | 100      | 1          | ?         |     1,062.12 ns |  1.00 |    5456 B | 
|                               |          |            |           |                 |       |           | 
| CreateBulk_Friflo             | 100      | 3          | ?         |     1,581.42 ns |  1.00 |    9712 B | 
|                               |          |            |           |                 |       |           | 
| CreateEntity_Friflo           | 100      | 1          | ?         |     3,202.37 ns |  1.00 |    5456 B | 
|                               |          |            |           |                 |       |           | 
| CreateEntity_Friflo           | 100      | 3          | ?         |     2,693.21 ns |  1.00 |    9712 B | 
|                               |          |            |           |                 |       |           | 
| CreateWorld_Friflo            | ?        | ?          | ?         |       310.78 ns |  1.00 |    7016 B | 
|                               |          |            |           |                 |       |           | 
| DeleteEntity_Friflo           | 100000   | 5          | ?         | 1,619,868.79 ns |  1.00 |     736 B | 
|                               |          |            |           |                 |       |           | 
| GetSetComponents_Friflo       | 100      | 1          | ?         |       203.79 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| GetSetComponents_Friflo       | 100      | 5          | ?         |       408.90 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100      | 1          | ?         |        50.88 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100      | 5          | ?         |        70.68 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100000   | 1          | ?         |    48,897.62 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100000   | 5          | ?         |    47,857.01 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryFragmented_Friflo        | 32       | ?          | ?         |        36.76 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| SearchComponentField_Friflo   | 1000000  | ?          | ?         |     4,678.92 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| SearchRange_Friflo            | 1000000  | ?          | ?         | 1,401,389.59 ns |  1.00 |  560001 B | 
