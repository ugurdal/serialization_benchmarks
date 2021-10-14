using System;
using BenchmarkDotNet.Running;

namespace serializationBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();

            Console.ReadKey();
        }
    }
}
