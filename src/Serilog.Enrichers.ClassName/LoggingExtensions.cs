using Serilog.Configuration;

namespace Serilog.Enrichers.ClassName
{
    public static class LoggingExtensions
    {
        public static LoggerConfiguration WithClassName(this LoggerEnrichmentConfiguration enrich)
        {
            _ = enrich ?? throw new ArgumentNullException(nameof(enrich));

            return enrich.With<ClassNameEnricher>();
        }
    }
}
