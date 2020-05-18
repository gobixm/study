using System.Linq;
using BenchmarkDotNet.Attributes;
using Gobi.SharpHost.Models;

namespace Gobi.SharpHost
{
    public class FfiBenchmark
    {
        private Foo _foo;

        [GlobalSetup]
        public void Setup()
        {
            _foo = new Foo
            {
                A = 0,
                B = 0,
                C = 0
            };
        }

        [Benchmark]
        public void MutateFooFfi()
        {
            foreach (var i in Enumerable.Range(0, 10000)) Api.FillFoo(ref _foo, i);
        }

        [Benchmark]
        public void MutateFooDotnet()
        {
            foreach (var i in Enumerable.Range(0, 10000))
            {
                _foo.A = i;
                _foo.B = i;
                _foo.C = i;
            }
        }
    }
}