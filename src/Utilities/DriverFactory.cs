using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SeleniumTestFramework.src.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    // Add any Chrome-specific options here
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    // Add any Firefox-specific options here
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    // Add any Edge-specific options here
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException("Browser not supported");
            }

            return driver;
        }

        public static void QuitDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}