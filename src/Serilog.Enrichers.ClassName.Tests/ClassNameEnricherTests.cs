using Serilog.Sinks.TestCorrelator;

namespace Serilog.Enrichers.ClassName.Tests
{
    public class ClassNameEnricherTests
    {
        [Fact]
        public void ClassNameProperty_MustExistAndMatch()
        {
            // Arrange
            const string expectedClassName = "ClassNameEnricher";
            var logger = new LoggerConfiguration()
                .Enrich.With(new ClassNameEnricher())
                .WriteTo.TestCorrelator()
                .CreateLogger()
                .ForContext("SourceContext", typeof(ClassNameEnricher).FullName);

            using (TestCorrelator.CreateContext())
            {
                // Act
                logger.Information("Test log");

                // Assert
                var logEvent = TestCorrelator.GetLogEventsFromCurrentContext().Single();
                Assert.NotNull(logEvent);

                // Verify if the UserId property is added
                Assert.True(logEvent.Properties.ContainsKey("ClassName"));
                Assert.Equal(expectedClassName, logEvent.Properties["ClassName"].ToString().Trim('"'));
            }
        }
    }
}