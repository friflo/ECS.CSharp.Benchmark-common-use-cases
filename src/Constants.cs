
public static class Constants
{
    // --- for Benchmark: AddRemoveComponentsT1, AddRemoveComponentsT5, QueryT1, QueryT5
    public const int EntityCount    = 1000;

    // --- for Benchmark: AddRemoveLinks
    public const int TargetCountP1  = 1;    // NOTE! Must be used only in [Params()]
    public const int TargetCountP2  = 100;  // NOTE! Must be used only in [Params()]
    
    // --- for Benchmark: CreateEntity
    public const int CreateEntityCount          = 1000;
    public const int CreateEntityIterationCount = 2000;
    
    // --- for Benchmark: DeleteEntity
    public const int DeleteEntityCount          = 1000;
    public const int DeleteEntityIterationCount = 2000;
}


public static class Assert
{
    public static void AreEqual<T>(T expect, T actual) where T : IEquatable<T>
    {
        var isEqual = EqualityComparer<T>.Default.Equals(expect, actual);
        if (!isEqual) {
            throw new AssertException($"expect: {expect}, was: {actual}");
        }
    }
}

public class AssertException : Exception
{
    public AssertException(string message) : base (message) { }
}