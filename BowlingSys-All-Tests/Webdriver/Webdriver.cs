using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace BowlingSYS_Tests.Webdriver
{
    public class Webdriver
    {
        IWebDriver driver;
        Serilog.ILogger logger;
        public Webdriver(Serilog.ILogger _logger)
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            driver = new ChromeDriver(options);
            logger = _logger;
        }


        public void GoToBowlingSYS()
        {
            driver.Navigate().GoToUrl(Settings.Settings.BowlingSysFrontend);
        }
        public void QuitWebdriver()
        {
            driver.Quit();
        }

        public void RetryableSeleniumElementInsert(string elementId, string text)
        {
            int retries = 0;
            By id = By.Id(elementId);

            while (retries < 5)
            {
                try
                {
                    driver.FindElement(id).SendKeys(text);
                    return;
                }
                catch (Exception e)
                {
                    retries++;
                    Thread.Sleep(500);

                    if (retries == 5)
                    {
                        logger.Error($"Failed to insert text into element with ID '{elementId}' after 5 retries.", e);
                    }
                }
            }
        }

        public void RetryableSeleniumElementClick(string elementId)
        {
            int retries = 0;
            By id = By.Id(elementId);

            while (retries < 5)
            {
                try
                {
                    driver.FindElement(id).Click();
                    return;
                }
                catch (Exception e)
                {
                    retries++;
                    Thread.Sleep(500);

                    if (retries == 5)
                    {
                        logger.Error($"Failed to Click into element with ID '{elementId}' after 5 retries.", e);
                    }
                }
            }
        }

        public void RetryableSeleniumELementFind(string elementClassname)
        {
            int retries = 0;
            By id = By.ClassName(elementClassname);

            while (retries < 5)
            {
                try
                {
                    driver.FindElement(id);
                    return;
                }
                catch (Exception e)
                {
                    retries++;
                    Thread.Sleep(1500);

                    if (retries == 5)
                    {
                        logger.Error($"Failed to Click into element with ID '{elementClassname}' after 5 retries.", e);
                    }
                }
            }

        }
    }
}
