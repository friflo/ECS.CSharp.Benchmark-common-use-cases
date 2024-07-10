// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

Console.WriteLine("Hello, World!");

ManualConfig customConfig = DefaultConfig.Instance
    .WithOption(ConfigOptions.JoinSummary, true)
    .WithArtifactsPath(@"../Artifacts")
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest))
//  .WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(TimeUnit.Microsecond))
    .AddDiagnoser(MemoryDiagnoser.Default)                                              // add column: Allocated
    .HideColumns("Error", "StdDev", "RatioSD", "Gen0", "Gen1", "Gen2", "Alloc Ratio");
    

BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
    .Run(args, customConfig);