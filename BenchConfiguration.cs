using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Validators;
using System.Runtime.CompilerServices;
using System.IO;
using System.Linq;

namespace CSharpBenchLab;

public class BenchConfiguration : ManualConfig
{
    public BenchConfiguration()
    {
        // Add standard loggers, column providers, etc. from DefaultConfig, but skip exporters
        AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
        AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray());
        AddJob(DefaultConfig.Instance.GetJobs().ToArray());
        AddValidator(DefaultConfig.Instance.GetValidators().ToArray());

        // Explicitly add columns and column providers to ensure they show up
        AddColumnProvider(DefaultColumnProviders.Instance);
        AddColumn(StatisticColumn.Mean, StatisticColumn.StdDev, StatisticColumn.Error);
        
        // Add MemoryDiagnoser to the config to ensure memory columns are present
        AddDiagnoser(MemoryDiagnoser.Default);
            
        // EXPORTERS: We explicitly bypass DefaultConfig Exporters and ONLY add Markdown
        AddExporter(MarkdownExporter.GitHub);

        //Uncomment to Disable .log file creation (if you don't want the raw log text)
        // Options |= ConfigOptions.DisableLogFile;
        ArtifactsPath = Path.Combine(GetProjectRoot(), "Docs/Results");
    }

    private string GetProjectRoot([CallerFilePath] string filePath = "")
    {
        return Path.GetDirectoryName(filePath) ?? AppContext.BaseDirectory;
    }
}