using Serilog;

namespace SerilogDemo
{
    internal class DemoClass
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<DemoClass>();

        public void DoWork()
        {
            Log.Information("Doing some work...");
        }
    }
}
