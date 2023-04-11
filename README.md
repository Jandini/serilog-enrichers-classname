# Serilog enricher for class name

[![Build](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/build.yml/badge.svg)](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/build.yml)
[![NuGet](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/nuget.yml/badge.svg)](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/nuget.yml)

Enrich Serilog logs with class name only.

## Quick Start

Use `.Enrich.WithClassName()` extension

```c#
internal static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
{
    return services.AddLogging(builder => builder
        .AddSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.WithClassName()
            .CreateLogger(), dispose: true));
}
```   

or add `"Enrich": [ "WithClassName" ]` to `appsettings.json` file

```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Enrichers.Environment" ],
    "MinimumLevel": "Information",
    "Enrich": [ "WithMachineName", "WithClassName" ],
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Code, Serilog.Sinks.Console",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u4}] [{MachineName}] [{ClassName}] {Message}{NewLine}{Exception}"
        }
      }
    ]
  }
}
```

Note: Since serilog can automatically find the enricher adding `"Using": [ "Serilog.Enrichers.ClassName" ]` is not required.  

---
Created from [JandaBox](https://github.com/Jandini/JandaBox)

Inspired by [Serilog.Enrichers.ShortTypeName](https://github.com/James-LG/serilog-enrichers-shorttypename)
