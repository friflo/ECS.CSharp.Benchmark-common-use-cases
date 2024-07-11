
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
    public const string     AddRemoveComponentsT1   = nameof(AddRemoveComponentsT1);
    public const string     AddRemoveComponentsT5   = nameof(AddRemoveComponentsT5);
    public const string     AddRemoveLinks          = nameof(AddRemoveLinks);
    public const string     CreateEntity            = nameof(CreateEntity);
    public const string     CreateWorld             = nameof(CreateWorld);
    public const string     DeleteEntity            = nameof(DeleteEntity);
    public const string     QueryT1                 = nameof(QueryT1);
    public const string     QueryT5                 = nameof(QueryT5);
    public const string     GetSetComponentsT1      = nameof(GetSetComponentsT1);
}
