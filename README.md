# ECS.CSharp.Benchmark Real World use-cases




CLI benchmark example commands
```
cd ./src

dotnet run -c Release --filter *
dotnet run -c Release --filter *AddRemoveComponents* *AddRemoveComponents* *CreateEntity* *CreateWorld* *DeleteEntity* *Query*
dotnet run -c Release --filter *AddRemoveLinks*
dotnet run -c Release --filter *Friflo*

--- macos
dotnet run -c Release --filter \*
dotnet run -c Release --filter \*AddRemoveComponents\* \*AddRemoveComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*AddRemoveLinks\*
dotnet run -c Release --filter \*Friflo\*
```




