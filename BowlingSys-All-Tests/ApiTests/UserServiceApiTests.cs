using OpenQA.Selenium.BiDi.Modules.Browser;
using NUnit.Framework;
using Serilog;
using BowlingSYS_Tests;
using BowlingSYS_Tests.Endtoend_Tests;

namespace BowlingSys_All_Tests.ApiTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UserServiceApiTests
    {
        private TestFixtures fixture;
        private ILogger logger;

        [SetUp]
        public void SetUp()
        {
            logger = LoggerConfig.ConfigureLogger();

            fixture = new TestFixtures(logger);
        }

        [Test]
        [Order(0)]
        public async Task CheckLogin()
        {
            try
            {
                await fixture.TestLoginApiTest(null, "pawelkaminski@ittralee.ie", "12345");

                logger.Information("CheckLogin test passed.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "CheckLogin test failed due to an exception.");
            }
        }
    }
}
