# ECS.CSharp.Benchmark Real World use-cases




CLI benchmark example commands
```shell
cd ./src

dotnet run -c Release --filter *                        # run all benchmarks
dotnet run -c Release --filter *AddRemoveComponents*    # run benchmarks of single category
dotnet run -c Release --filter *Friflo*                 # run benchmarks of single project
dotnet run -c Release --filter *Friflo* *Arch*          # compare benchmarks of two projects

dotnet run -c Release --filter *AddRemoveComponents* *AddRemoveComponents* *GetSetComponents* *CreateEntity* *CreateWorld* *DeleteEntity* *Query*

--- macos
dotnet run -c Release --filter \*                       # run all benchmarks
dotnet run -c Release --filter \*AddRemoveComponents\*  # run benchmarks of single category
dotnet run -c Release --filter \*Friflo\*               # run benchmarks of single project
dotnet run -c Release --filter \*Friflo\* \*Arch\*      # compare benchmarks of two projects
dotnet run -c Release --filter \*AddRemoveComponents\* \*AddRemoveComponents\* \*GetSetComponents\* \*CreateEntity\* \*CreateWorld\* \*DeleteEntity\* \*Query\*
```




