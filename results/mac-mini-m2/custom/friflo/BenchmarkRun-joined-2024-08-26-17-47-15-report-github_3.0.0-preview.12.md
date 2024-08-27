```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.6.1 (23G93) [Darwin 23.6.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.303
  [Host]     : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-EHWURL : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD
  Job-IVWEWQ : .NET 8.0.7 (8.0.724.31311), Arm64 RyuJIT AdvSIMD

Method=Run  IterationCount=Default  LaunchCount=Default  

```
| Type                          | Entities | Components | Relations | Mean            | Ratio | Allocated | 
|------------------------------ |--------- |----------- |---------- |----------------:|------:|----------:|
| AddRemoveComponents_Friflo    | 100      | 1          | ?         |     1,530.79 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveComponents_Friflo    | 100      | 5          | ?         |     5,983.11 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveLinks_Friflo         | 100      | ?          | 1         |     5,901.41 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveLinks_Friflo         | 100      | ?          | 100       | 1,248,938.23 ns |  1.00 |       1 B | 
|                               |          |            |           |                 |       |           | 
| AddRemoveRelations_Friflo     | 100      | ?          | 1         |     3,745.93 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| AddRemoveRelations_Friflo     | 100      | ?          | 100       |    46,959.62 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| ChildEntitiesAddRemove_Friflo | 100      | ?          | ?         |    25,682.40 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| CommandBufferAddRemove_Friflo | 100      | ?          | ?         |     7,986.88 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| ComponentEvents_Friflo        | 100      | ?          | ?         |     1,794.64 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| CreateBulk_Friflo             | 100      | 1          | ?         |     1,073.38 ns |  1.00 |    5456 B | 
|                               |          |            |           |                 |       |           | 
| CreateBulk_Friflo             | 100      | 3          | ?         |     1,857.01 ns |  1.01 |    9712 B | 
|                               |          |            |           |                 |       |           | 
| CreateEntity_Friflo           | 100      | 1          | ?         |     3,099.19 ns |  1.00 |    5456 B | 
|                               |          |            |           |                 |       |           | 
| CreateEntity_Friflo           | 100      | 3          | ?         |     2,788.50 ns |  1.00 |    9712 B | 
|                               |          |            |           |                 |       |           | 
| CreateWorld_Friflo            | ?        | ?          | ?         |       312.90 ns |  1.00 |    7024 B | 
|                               |          |            |           |                 |       |           | 
| DeleteEntity_Friflo           | 100000   | 5          | ?         | 1,624,610.36 ns |  1.00 |     736 B | 
|                               |          |            |           |                 |       |           | 
| GetSetComponents_Friflo       | 100      | 1          | ?         |       205.69 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| GetSetComponents_Friflo       | 100      | 5          | ?         |       407.43 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100      | 1          | ?         |        50.74 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100      | 5          | ?         |        70.21 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100000   | 1          | ?         |    48,555.46 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryComponents_Friflo        | 100000   | 5          | ?         |    48,015.02 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| QueryFragmented_Friflo        | 32       | ?          | ?         |        36.86 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| SearchComponentField_Friflo   | 1000000  | ?          | ?         |     4,669.19 ns |  1.00 |         - | 
|                               |          |            |           |                 |       |           | 
| SearchRange_Friflo            | 1000000  | ?          | ?         | 1,395,802.43 ns |  1.00 |  560001 B | 
