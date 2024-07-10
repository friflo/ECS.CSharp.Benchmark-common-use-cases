// See https://aka.ms/new-console-template for more information

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
    .AddLogicalGroupRules(BenchmarkLogicalGroupRule.ByMethod)
//  .WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(TimeUnit.Microsecond))
    .AddDiagnoser(MemoryDiagnoser.Default)                                          // add column: Allocated
    .HideColumns("Method", "Error", "StdDev", "RatioSD", "Gen0", "Gen1", "Gen2");   // last column "Alloc Ratio" not hidden otherwise Markdown table is in valid 
    

BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
#if DEBUG
    .Run(args, new DebugInProcessConfig());
#else
    .Run(args, customConfig);
#endif