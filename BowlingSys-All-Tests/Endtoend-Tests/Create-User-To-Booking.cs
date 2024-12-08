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
        private string name = "PawelTest1";
        private string password = "12345";
        private string email = "PawelTest1@gmail.com";



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

            await fixture.TestInsertUserApi(name, email, password);
        }

        [Test]
        [Order(1)]
        public async Task TestLoginApiTest()
        {
            await fixture.TestLoginApiTest(name, email, password);
        }

        [Test]
        [Order(2)]
        public async Task TestInsertBookingApi()
        {
            await fixture.TestInsertBookingApi(200, "12", 3);
        }


        [Test]
        [Order(3)]
        public async Task TestLoginUI()
        {
            fixture.TestLogin(email, password);
        }

        [Test]
        [Order(4)]
        public async Task TestBookingUI()
        {
            fixture.TestBookingsLoad();
        }


        [OneTimeTearDown]
        public async Task CleanUp()
        {
            fixture.Quit();
        }

    }
}
