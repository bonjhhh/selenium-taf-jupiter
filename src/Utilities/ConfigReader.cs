using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SeleniumTestFramework.Utilities
{
    public class ConfigReader
    {
        private readonly JObject _config;

        public ConfigReader(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                _config = JObject.Parse(jsonData);
            }
            else
            {
                throw new FileNotFoundException("Configuration file not found", filePath);
            }
        }

        public string Get(string key)
        {
            return _config[key]?.ToString();
        }
    }
}