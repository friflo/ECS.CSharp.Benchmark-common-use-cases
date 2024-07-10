
using BenchmarkDotNet.Attributes;


public static class Constant
{
    /// NOTE! Constants must be used only in <see cref="ParamsAttribute"/>
    public const int TargetCountP1  = 1;
    /// NOTE! Constants must be used only in <see cref="ParamsAttribute"/>
    public const int TargetCountP2  = 100;
    
    public const int EntityCount    = 1;
    
    public const int CreateEntityIterationCount = 1000;    
    public const int CreateEntityCount          = 1000;
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