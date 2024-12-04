# Serilog enricher for class name

[![Build](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/build.yml/badge.svg)](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/build.yml)
[![NuGet](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/nuget.yml/badge.svg)](https://github.com/Jandini/serilog-enrichers-classname/actions/workflows/nuget.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Serilog.Enrichers.ClassName?style=flat&label=Version)](https://www.nuget.org/packages/Serilog.Enrichers.ClassName/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Serilog.Enrichers.ClassName.svg?style=flat&label=Version)](https://www.nuget.org/packages/Serilog.Enrichers.ClassName)

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

Note: Since serilog can automatically find the enricher adding `"Using": [ "Serilog.Enrichers.ClassName" ]` is not required. You must add if you use use `-p:PublishSingleFile=true`.

### Publish you application as single file 

When publishing application with `-p:PublishSingleFile=true` you must include `"Using": [ "Serilog.Enrichers.ClassName" ]` in appsettings.json.
Without this the enricher will not be loaded and the value will be empty.
For example: 
```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File", "Serilog.Enrichers.Environment", "Serilog.Enrichers.ClassName" ],
    ...
  }
}
```
---
Created from [JandaBox](https://github.com/Jandini/JandaBox)

Inspired by [Serilog.Enrichers.ShortTypeName](https://github.com/James-LG/serilog-enrichers-shorttypename)
