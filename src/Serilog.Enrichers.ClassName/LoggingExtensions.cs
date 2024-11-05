using Serilog.Configuration;
using System.Diagnostics;

namespace Serilog;

public static class LoggingExtensions
{
    public static LoggerConfiguration WithClassName<T>(this LoggerEnrichmentConfiguration enrich) where T : class
    {
        _ = enrich ?? throw new ArgumentNullException(nameof(enrich));

        enrich.WithProperty("SourceContext", typeof(T).FullName);
        return enrich.With<ClassNameEnricher>();
    }

    public static LoggerConfiguration WithClassName(this LoggerEnrichmentConfiguration enrich)
    {
        _ = enrich ?? throw new ArgumentNullException(nameof(enrich));

        var stackFrame = new StackTrace().GetFrame(1);
        var declaringType = stackFrame?.GetMethod()?.DeclaringType;

        enrich.WithProperty("SourceContext", declaringType?.FullName ?? "Unknown");
        return enrich.With<ClassNameEnricher>();
    }
}
