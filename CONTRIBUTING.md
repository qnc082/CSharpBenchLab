# Contributing to CSharpBenchLab

Thank you for your interest in contributing to **CSharpBenchLab**!

## How to Add a New Benchmark

1. **Create Your Benchmark:**
   - Add your new benchmark class to the appropriate folder under [`/Benchmarks`](Benchmarks).
   - Use the `[Config(typeof(BenchConfiguration))]` attribute on your benchmark class to ensure results are exported in the correct format and location.

2. **Follow Best Practices:**
   - Use descriptive class and method names.
   - Add `[MemoryDiagnoser]` if you want to track memory allocations.
   - Seed any required data in `[GlobalSetup]` methods.

3. **Submit a Pull Request:**
   - Fork the repository and create a new branch for your changes.
   - Submit a Pull Request (PR) with a clear description of your benchmark and its purpose.

## Review Process

- All PRs will be reviewed for clarity, correctness, and relevance.
- Once approved, your benchmark will be included in the next results export to [`/Docs/Results`](./Docs/Results).

Thank you for helping make CSharpBenchLab a valuable resource for the C# community!
