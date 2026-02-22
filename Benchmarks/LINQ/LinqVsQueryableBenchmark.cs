using BenchmarkDotNet.Attributes;
using CSharpBenchLab.Data;

namespace CSharpBenchLab.Benchmarks.LINQ
{
    [Config(typeof(BenchConfiguration))]
    [MemoryDiagnoser]
    public class LinqVsQueryableBenchmark
    {
        private AppDbContext _context = null!;
        private string _department = "Engineering";

        [GlobalSetup]
        public void GlobalSetup()
        {
            _context = AppDbContext.CreateWithSeedData();
        }

        [Benchmark]
        public int FilterWithIEnumerable()
        {
            // Materialize first, then filter in-memory
            return _context.Employees
                .ToList()
                .Where(e => e.Department == _department)
                .Count();
        }

        [Benchmark]
        public int FilterWithIQueryable()
        {
            // Filter in database, then materialize
            return _context.Employees
                .Where(e => e.Department == _department)
                .ToList()
                .Count;
        }
    }
}