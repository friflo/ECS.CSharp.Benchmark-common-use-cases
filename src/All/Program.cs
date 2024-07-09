// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

ManualConfig customConfig = DefaultConfig.Instance.WithArtifactsPath(@"../Artifacts");
BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
    .Run(args, customConfig);