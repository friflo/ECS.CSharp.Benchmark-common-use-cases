// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

var header =
$@"
    ECS.CSharp.Benchmark Common use-cases
    -------------------------------------
    {nameof(Constants.EntityCount)}:        {Constants.EntityCount}
    {nameof(Constants.CreateEntityCount)}:  {Constants.CreateEntityCount}
    {nameof(Constants.DeleteEntityCount)}:  {Constants.DeleteEntityCount}
    args: {string.Join(' ', args)}
";

ManualConfig customConfig = DefaultConfig.Instance
    .WithOption(ConfigOptions.JoinSummary, true)
    .WithArtifactsPath(@"../Artifacts")
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest))
    .AddLogicalGroupRules(BenchmarkLogicalGroupRule.ByCategory)
//  .WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(TimeUnit.Microsecond))
    .AddDiagnoser(MemoryDiagnoser.Default)                      // adds column: Allocated
    .HideColumns(
        "Method", "Error", "StdDev", "Median",                  // removed to reduce noise
        "RatioSD",                                              // added by using: [Benchmark(Baseline = true)]
        "InvocationCount", "IterationCount", "UnrollFactor",    // added by using: [InvocationCount()] & [IterationCount()]
        "Job", "LaunchCount", "WarmupCount",                    // added by using: [IterationSetup] & [IterationCleanup]
        "Gen0", "Gen1", "Gen2", "Alloc Ratio");                 // removing last column "Alloc Ratio" makes Markdown table valid

    // ReSharper disable once RedundantAssignment
    IConfig config = customConfig;
#if DEBUG
    config = new DebugInProcessConfig();
#endif
    foreach (var logger in config.GetLoggers()) { logger.WriteLine(header); }

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args, config);


public static class Check
{
    public static void AreEqual(int expect, int actual)
    {
        var isEqual = expect == actual;
        if (!isEqual) {
            throw new AssertException($"expect: {expect}, was: {actual}");
        }
    }
}

public class AssertException : Exception
{
    public AssertException(string message) : base (message) { }
}