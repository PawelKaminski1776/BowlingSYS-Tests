using Serilog;

namespace BowlingSYS_Tests
{
    public class LoggerConfig
    {
        public static ILogger ConfigureLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                //.WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Debug()
                .CreateLogger();
        }
    }
}
