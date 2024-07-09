// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

BenchmarkSwitcher
    .FromAssembly(Assembly.GetExecutingAssembly())
    .Run(args);