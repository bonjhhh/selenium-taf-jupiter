using Microsoft.Extensions.Configuration;
using System.IO;

namespace SeleniumTestFramework.src.Config
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration;
        private static readonly WebDriverConfig WebDriverConfig;

        static ConfigurationHelper()
        {
            string baseDirectory = Directory.GetCurrentDirectory().Split("bin")[0];
            string configPath = Path.Combine(baseDirectory, "src", "Config", "Config.json");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configPath))
                .AddJsonFile("Config.json")
                .Build();

            WebDriverConfig = Configuration.Get<WebDriverConfig>();
        }

        public static int GetWebDriverTimeoutSeconds()
        {
            return WebDriverConfig?.WebDriver?.TimeoutInSeconds ?? 30;
        }

        public static double GetWebDriverPollingIntervalSeconds()
        {
            return WebDriverConfig?.WebDriver?.PollingIntervalInSeconds ?? 0.5;
        }
    }
}