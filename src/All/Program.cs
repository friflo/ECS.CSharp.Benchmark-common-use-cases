// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

ManualConfig customConfig = DefaultConfig.Instance
    .WithArtifactsPath(@"../Artifacts")
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest))
    .AddDiagnoser(MemoryDiagnoser.Default)                                  // adds column: Allocated
    .WithOption(ConfigOptions.JoinSummary, true);

BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
    .Run(args, customConfig);