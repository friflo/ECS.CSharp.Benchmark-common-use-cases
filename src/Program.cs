﻿// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

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
        "Gen0", "Gen1", "Gen2", "Alloc Ratio");                 // removing last column "Alloc Ratio" makes Markdown table valid
    

BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
#if DEBUG
    .Run(args, new DebugInProcessConfig());
#else
    .Run(args, customConfig);
#endif


public static class Assert
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