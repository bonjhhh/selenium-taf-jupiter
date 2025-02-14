using System;

namespace SeleniumTestFramework.src.Config
{
    public class WebDriverConfig
    {
        public class WebDriverSettings
        {
            public int TimeoutInSeconds { get; set; }
            public double PollingIntervalInSeconds { get; set; }
        }

        public WebDriverSettings WebDriver { get; set; }
    }
}