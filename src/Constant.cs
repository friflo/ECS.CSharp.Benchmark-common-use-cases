
using BenchmarkDotNet.Attributes;

/// <summary>
/// NOTE!
/// Constants must bu used only in <see cref="ParamsAttribute"/>
/// </summary>
public static class Constant
{
    public const int TargetCountP1  = 1;
    public const int TargetCountP2  = 10;
    public const int TargetCountP3  = 100;
    
    public const int EntityCountP1  = 1000;
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