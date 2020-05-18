using BenchmarkDotNet.Running;

namespace Gobi.SharpHost
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<FfiBenchmark>();
        }
    }
}