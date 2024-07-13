
public static class Constants
{
    // --- for Benchmark: AddRemoveComponentsT1, AddRemoveComponentsT5, QueryT1, QueryT5
    public const int    EntityCount         = 100;

    // --- for Benchmark: AddRemoveLinks
    public const int    TargetCountP1       = 1;        // NOTE! Must be used only in [Params()]
    public const int    TargetCountP2       = 100;      // NOTE! Must be used only in [Params()]
    
    // --- for Benchmark: CreateEntityT1 & CreateEntityT3 
    public const int    CreateEntityCount   = 100_000;
    
    // --- for Benchmark: DeleteEntity
    public const int    DeleteEntityCount   = 100_000;  // each entity has 5 components
    
    // --- for Benchmark: SearchComponentField
    public const int    SearchSetSize       = 100_000;  // number of components having a field that can be searched
    public const int    SearchCount         = 1000;     // number of executed searches 
}


// --- Benchmark categories
public static class Category
{
    public const string     AddRemoveComponentsT1       = nameof(AddRemoveComponentsT1);
    public const string     AddRemoveComponentsT5       = nameof(AddRemoveComponentsT5);
    public const string     CreateEntityT1              = nameof(CreateEntityT1);
    public const string     CreateEntityT3              = nameof(CreateEntityT3);
    public const string     CreateWorld                 = nameof(CreateWorld);
    public const string     DeleteEntity                = nameof(DeleteEntity);
    public const string     GetSetComponentsT1          = nameof(GetSetComponentsT1);
    public const string     QueryT1                     = nameof(QueryT1);
    public const string     QueryT5                     = nameof(QueryT5);

    // --- projects supporting: Relations
    public const string     AddRemoveLinks              = nameof(AddRemoveLinks);

    // --- projects supporting: Command buffers
    public const string     CommandBufferAddRemoveT2    = nameof(CommandBufferAddRemoveT2);
    
    // --- projects supporting: Searching component fields
    public const string     SearchComponentField        = nameof(SearchComponentField);
}
