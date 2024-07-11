# ECS.CSharp.Benchmark Real World use-cases




CLI benchmark example commands
```shell
cd ./src

dotnet run -c Release --filter *
dotnet run -c Release --filter *AddRemoveComponents* *AddRemoveComponents* *CreateEntity* *CreateWorld* *DeleteEntity* *Query*
dotnet run -c Release --filter *AddRemoveLinks*         # benchmark category
dotnet run -c Release --filter *Friflo*                 # benchmark single project
dotnet run -c Release --filter *Friflo* *Arch*          # compare two projects

--- macos
dotnet run -c Release --filter \*
dotnet run -c Release --filter \*AddRemoveComponents\* \*AddRemoveComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
dotnet run -c Release --filter \*AddRemoveLinks\*       # benchmark category
dotnet run -c Release --filter \*Friflo\*               # benchmark single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*      # compare two projects
```




