
public static class Constant
{
    public const int SourceEntitiesCount    = 1000;
    public const int EntityCount            = 10;
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