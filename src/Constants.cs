
public static class Constants
{
    // --- for Benchmark: AddRemoveComponentsT1, AddRemoveComponentsT5, QueryT1, QueryT5
    public const int    EntityCount         = 100;
    public const int    FragmentationCount  = 32;

    // --- for Benchmark: ChildEntitiesAddRemove
    public const int    ChildCount          = 10;

    // --- for Benchmark: CreateEntity
    public const int    CreateEntityCount   = 100;

    // --- for Benchmark: CreateBulk
    public const int    CreateBulkCount     = 100;

    // --- for Benchmark: DeleteEntity
    public const int    DeleteEntityCount   = 100_000;      // each entity has 5 components

    // --- for Benchmark: SearchComponentField
    public const int    SearchSetSize       = 1_000_000;    // number of components having a field that can be searched
    public const int    SearchCount         = 1000;         // number of executed searches / range queries

    // --- for Benchmark: ComponentEvents
    public const int    EventCount          = 100;          // number of component add / remove events
}


// --- Benchmark categories
public static class Category
{
    // --- Basic features
    public const string     AddRemoveComponents         = nameof(AddRemoveComponents);
    public const string     ComponentEvents             = nameof(ComponentEvents);
    public const string     CreateEntity                = nameof(CreateEntity);
    public const string     CreateBulk                  = nameof(CreateBulk);
    public const string     CreateWorld                 = nameof(CreateWorld);
    public const string     DeleteEntity                = nameof(DeleteEntity);
    public const string     GetSetComponents            = nameof(GetSetComponents);
    public const string     QueryFragmentedT1           = nameof(QueryFragmentedT1);
    public const string     QueryComponents             = nameof(QueryComponents);

    // --- projects supporting: Relations
    public const string     AddRemoveLinks              = nameof(AddRemoveLinks);
    public const string     AddRemoveRelations          = nameof(AddRemoveRelations);
    public const string     ChildEntitiesAddRemove      = nameof(ChildEntitiesAddRemove);


    // --- projects supporting: Command buffers
    public const string     CommandBufferAddRemoveT2    = nameof(CommandBufferAddRemoveT2);

    // --- projects supporting: Search
    public const string     SearchComponentField        = nameof(SearchComponentField);
    public const string     SearchRange                 = nameof(SearchRange);  // aka range query
}
