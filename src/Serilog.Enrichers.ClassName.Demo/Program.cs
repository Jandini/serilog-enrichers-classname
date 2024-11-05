// See https://aka.ms/new-console-template for more information
// Configure Serilog with SourceContext
using Serilog;
using Serilog.Enrichers.ClassName;
using SerilogDemo;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithClassName()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{ClassName}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

    Log.Information("Application starting...");

// Log from another class
var demoClass = new DemoClass();
    demoClass.DoWork();

Log.Information("Application ending...");
Log.CloseAndFlush();
    
