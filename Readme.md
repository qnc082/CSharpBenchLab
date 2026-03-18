# CSharpBenchLab

**CSharpBenchLab** is a community-driven benchmark repository for C# developers. It provides a collection of benchmarks focused on:

- Data Structures
- LINQ
- Spans
- Database Queries

Our goal is to help the community understand the performance characteristics of common C# patterns and libraries.

## How to Run Benchmarks from CLI

To get started with running benchmarks locally, follow these steps:

### 1. Prerequisites
Ensure you have the .NET SDK installed (this project currently uses .NET 10.0).

### 2. Build the Project

> [!IMPORTANT]
> It is highly recommended to run benchmarks in **Release** mode to ensure accuracy. Running in Debug mode will result in significantly skewed performance data.

```powershell
dotnet build -c Release
```

### 3. Discover Available Benchmarks
To see a list of all benchmarks that can be executed:
```powershell
dotnet run -c Release -- --list flat
```

### 4. Run Benchmarks
You can run all benchmarks or target specific ones using filters.

**Run All Benchmarks:**
```powershell
dotnet run -c Release
```

**Run Specific Benchmarks (Filtering):**

> [!TIP]
> Use the `--filter` flag with wildcards (`*`) to target specific classes or methods.

```powershell
# Target a specific class
dotnet run -c Release -- --filter *LinqVsQueryableBenchmark*

# Target a specific method name across all classes
dotnet run -c Release -- --filter *FilterWithIQueryable*
```

## Benchmark Results

All benchmark results are automatically exported as GitHub-flavored Markdown files to the [`/Docs/Results`](./Docs/Results) directory.

### Configuration Details
Our setup is optimized for clean reporting:
- **Exporters**: Markdown only (CSV and HTML are excluded).
- **Metrics**: Standard performance (Mean, StdDev, Error) and memory allocations (Gen 0/1/2, Allocated).

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](./CONTRIBUTING.md) for guidelines on how to add your own benchmarks.
