
public static class Constants
{
    // --- for Benchmark: AddRemoveComponentsT1, AddRemoveComponentsT5, QueryT1, QueryT5
    public const int    EntityCount    = 1000;

    // --- for Benchmark: AddRemoveLinks
    public const int    TargetCountP1  = 1;     // NOTE! Must be used only in [Params()]
    public const int    TargetCountP2  = 100;   // NOTE! Must be used only in [Params()]
    
    // --- for Benchmark: CreateEntity
    public const int    CreateEntityCount          = 1000;
    public const int    CreateEntityIterationCount = 2000;
    
    // --- for Benchmark: DeleteEntity
    public const int    DeleteEntityCount          = 1000;
    public const int    DeleteEntityIterationCount = 2000;
}


// --- Benchmark categories
public static class Category
{
    public const string     AddRemoveComponentsT1   = "AddRemoveComponentsT1";
    public const string     AddRemoveComponentsT5   = "AddRemoveComponentsT5";
    public const string     AddRemoveLinks          = "AddRemoveLinks";
    public const string     CreateEntity            = "CreateEntity";
    public const string     CreateWorld             = "CreateWorld";
    public const string     DeleteEntity            = "DeleteEntity";
    public const string     QueryT1                 = "QueryT1";
    public const string     QueryT5                 = "QueryT5";
    public const string     GetSetComponentsT1      = "GetSetComponentsT1";
}
