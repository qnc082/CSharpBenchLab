# CSharpBenchLab - AI Agents Guide

Welcome, AI Agents! This guide is designed to help you quickly understand the structure, architecture, development workflow, and commands of the **CSharpBenchLab** repository so you can effectively implement new benchmarks, debug issues, or make improvements.

---

## 1. Project Overview & Tech Stack

**CSharpBenchLab** is a console-based benchmark runner built on:
- **Runtime/SDK**: `.NET 10.0`
- **Benchmarking Engine**: `BenchmarkDotNet (v0.15.8)`
- **Data Generation**: `Bogus (v35.6.5)`
- **Database / ORM**: `EF Core (InMemory & Sqlite v10.0.3)`

---

## 2. Directory Structure

Here is an overview of the codebase organization:

```text
CSharpBenchLab/
├── .github/                       # GitHub workflow, issues, and PR templates
├── Benchmarks/                    # Benchmark categories
│   ├── Collections/               # Benchmarks for lists, dictionaries, spans, etc.
│   ├── Database/                  # Database query benchmarks (EF Core vs. Dapper/etc.)
│   └── LINQ/                      # LINQ query patterns vs. queryable performance
├── Data/                          # Mock database and data generation
│   ├── Models/                    # Entity models (e.g., Employee.cs)
│   ├── AppDbContext.cs            # EF Core DbContext with in-memory SQLite support/seeding
│   └── MockDataGenerator.cs       # Mock data generator using Bogus
├── Docs/
│   └── Results/                   # Target directory for exported markdown results
├── AGENTS.md                      # AI agents guide (this file)
├── Program.cs                     # Main entrypoint executing BenchmarkSwitcher
├── BenchConfiguration.cs          # Custom configuration for BenchmarkDotNet exports
└── CSharpBenchLab.csproj          # Project dependencies and targets
```

---

## 3. Configuration & Exporters

The project uses a custom BenchmarkDotNet configuration defined in [BenchConfiguration.cs](./BenchConfiguration.cs):
* **Markdown Only**: Excludes HTML and CSV exporters. GitHub-flavored markdown is generated directly to `/Docs/Results/`.
* **Columns**: Mean, StdDev, Error, and Memory allocations (Gen 0, Gen 1, Gen 2, Allocated).
* **Memory Diagnoser**: Pre-configured globally to track allocations.
* **Auto-Discovery**: [Program.cs](./Program.cs) uses `BenchmarkSwitcher` configured with `BenchConfiguration` to run any benchmarks discovered in the assembly.

---

## 4. Development Workflow

### Adding a New Benchmark
When creating or modifying benchmarks, follow these conventions:

1. **Location**: Place the benchmark class in the correct category under [Benchmarks/](./Benchmarks) (e.g., `Benchmarks/Collections/`).
2. **Annotation**:
   - Use the `[MemoryDiagnoser]` attribute on your class to profile allocation metrics.
   - You can also apply `[Config(typeof(BenchConfiguration))]` directly to the class (as noted in [CONTRIBUTING.md](./CONTRIBUTING.md)), although [Program.cs](./Program.cs) runs the switcher with this configuration by default.
3. **Data Seeding**:
   - Seed mock data using EF Core or memory models in a `[GlobalSetup]` method.
   - For database benchmarks, utilize [AppDbContext.CreateWithSeedData()](./Data/AppDbContext.cs#L15) to retrieve an EF database populated with `10,000` pre-generated employee records.
4. **Clean Code**: Keep benchmark methods focused solely on the operation being measured to avoid polluting performance results with setup or teardown overhead.

---

## 5. Developer & CLI Commands

Always perform benchmark operations in **Release** configuration. Running benchmarks in Debug configuration will trigger warnings and distort performance metrics.

| Task | Command |
| :--- | :--- |
| **Build Project** | `dotnet build -c Release` |
| **List Benchmarks** | `dotnet run -c Release -- --list flat` |
| **Run All Benchmarks** | `dotnet run -c Release` |
| **Run Specific Benchmark** | `dotnet run -c Release -- --filter *BenchmarkClassName*` |
| **Run Specific Method** | `dotnet run -c Release -- --filter *MethodName*` |

---

## 6. Verification and Export

1. Before committing, run a project build to ensure compilation succeeds:
   ```powershell
   dotnet build
   ```
2. After running a benchmark, check the `/Docs/Results/` folder to verify the generated `*.md` files are correct and updated.
