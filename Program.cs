using BenchmarkDotNet.Running;
using CSharpBenchLab;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new BenchConfiguration());
    }
}