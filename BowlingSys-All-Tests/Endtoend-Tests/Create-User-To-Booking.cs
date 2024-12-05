using BowlingSYS_Tests.Endtoend_Tests;
using BowlingSYS_Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace BowlingSys_All_Tests.Endtoend_Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class CreateUserToBooking
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
        public async Task InsertUserApi()
        {
            string name = "PawelTest1";
            string password = "12345";
            string email = "PawelTest1@gmail.com";


            await fixture.TestInsertUserApi(name, email, password);
            await fixture.TestLoginApiTest(name, email, password);
            await fixture.TestInsertBookingApi(200, "12", 3);
            fixture.TestLogin(email, password);
            fixture.TestBookingsLoad();
            fixture.Quit();
        }
    }
}
