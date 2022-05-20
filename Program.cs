using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;


namespace Benchmark
{

    public class Parsing
    {
        public int ParseWithTryCatch(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int TryParse(string str)
        {
            int result;
            int.TryParse(str, out result);
            return result;
        }

    }

    [MemoryDiagnoser]
    [RankColumn]
    public class My_Benchmark
    {
        private string str_err = "qwerty12345";
        private string str = "12345";

        private readonly Parsing _parse = new Parsing();

        [Benchmark]
        public void ParseWithError()
        {
            _parse.ParseWithTryCatch(str_err);
        }

        [Benchmark]
        public void TryParseWithError()
        {
            _parse.TryParse(str_err);
        }

        [Benchmark]
        public void ParseWithOutError()
        {
            _parse.ParseWithTryCatch(str);
        }

        [Benchmark]
        public void TryParseWithOutError()
        {
             _parse.TryParse(str);
        }


    }

    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
