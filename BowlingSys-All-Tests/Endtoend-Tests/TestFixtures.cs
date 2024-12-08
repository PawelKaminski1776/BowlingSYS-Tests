using System;
using System.Globalization;
using BowlingSys.Entities.UserDBEntities;
using BowlingSys_All_Tests.Builders;
using BowlingSYS_Tests.Builders;
using BowlingSYS_Tests.Httpclient;
using OpenQA.Selenium;
using Serilog;

namespace BowlingSYS_Tests.Endtoend_Tests
{
    public class TestFixtures
    {
        private readonly ILogger _logger;
        private Guid UserID {  get; set; }
        Webdriver.Webdriver webdriver;
        public TestFixtures(ILogger logger)
        {
            logger = LoggerConfig.ConfigureLogger();
            _logger = logger;
            webdriver = new Webdriver.Webdriver(_logger);
        }

        public async Task TestLoginApiTest(string? username, string? email, string password)
        {
            Httpclient.Httpclient client = new Httpclient.Httpclient(Settings.Settings.UserServiceUrl, _logger);
            try
            {
                var queryParams = new Dictionary<string, string?>
                {
                     { "username", username },
                     { "email", email },
                     { "password", password }
                };

                var response = await client.GetAsync(Settings.Settings.UserServiceUrl + "/CheckLogin", queryParams);
                GetUserIDResult Result = Newtonsoft.Json.JsonConvert.DeserializeObject<GetUserIDResult>(response);

                UserID = Result.User_Id;

                _logger.Information(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while testing the CreateAccount API.");
            }
        }

        public async Task TestInsertUserApi(string username, string email, string password)
        {
            Httpclient.Httpclient client = new Httpclient.Httpclient(Settings.Settings.UserServiceUrl, _logger);
            try
            {
                AddUser addUser = new AddUser(username, password, email);

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(addUser.UserCreationBuilder());
                var response = await client.PostAsync(Settings.Settings.UserServiceUrl + "/AddNewAccount", jsonText);
                _logger.Information(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while testing the CreateAccount API.");
            }
        }

        public async Task TestInsertBookingApi(decimal bookingCost, string bookingTime, int numOfShoes)
        {
            Httpclient.Httpclient client = new Httpclient.Httpclient(Settings.Settings.UserServiceUrl, _logger);
            try
            {

                AddBooking builder = new AddBooking(UserID, bookingCost, bookingTime, numOfShoes);

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(builder.MakeBookingBuilder());

                var response = await client.PostAsync(Settings.Settings.MakeBookingServiceUrl + "/SendBooking", jsonText);
                _logger.Information(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while testing the CreateAccount API.");
            }
        }


        public void TestLogin(string email, string password)
        {
            webdriver = new Webdriver.Webdriver(_logger);
            webdriver.GoToBowlingSYS();
            webdriver.RetryableSeleniumElementClick("login-button");
            webdriver.RetryableSeleniumElementInsert("sign-in-form-username", email);
            webdriver.RetryableSeleniumElementInsert("sign-in-form-password", password);
            webdriver.RetryableSeleniumElementClick("login-button-click");
            webdriver.RetryableSeleniumELementFind("booking-item");
        }

        public void TestBookingsLoad()
        {
            webdriver.RetryableSeleniumELementFind("booking-item");
        }

        public void Quit()
        {
            webdriver.QuitWebdriver();
        }
    }
}
