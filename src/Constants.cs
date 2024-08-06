
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
