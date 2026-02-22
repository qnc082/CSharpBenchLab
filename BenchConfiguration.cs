using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;

namespace CSharpBenchLab
{
    public class BenchConfiguration : ManualConfig
    {
        public BenchConfiguration()
        {
            AddExporter(HtmlExporter.Default);
            ArtifactsPath = Path.Combine(AppContext.BaseDirectory, "Docs/Results");
        }
    }
}