using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.ClassName
{
    public class ClassNameEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _ = logEvent ?? throw new ArgumentNullException(nameof(logEvent));
            _ = propertyFactory ?? throw new ArgumentNullException(nameof(propertyFactory));

            if (logEvent.Properties.TryGetValue("SourceContext", out var value))
            {
                var source = value.ToString("l", null).Split('.').Last();

                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ClassName", source));
            }
        }
    }
}
