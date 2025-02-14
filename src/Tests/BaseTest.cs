using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestFramework.src.Utilities;
using Serilog;
using System;
using System.IO;

namespace SeleniumTestFramework.src.Tests
{


    public class BaseTest
    {
        protected IWebDriver driver;
        protected static readonly ILogger Logger;

        static BaseTest()
        {
            try
            {
                // Get the solution directory (project root)
                string currentDirectory = Directory.GetCurrentDirectory();
                string solutionDirectory = currentDirectory.Split("bin")[0];
                string logDirectory = Path.Combine(solutionDirectory, "logs");

                Console.WriteLine($"Creating log directory at: {logDirectory}");

                // Ensure directory exists
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                    Console.WriteLine("Log directory created successfully");
                }

                string logFilePath = Path.Combine(logDirectory, $"test_{DateTime.Now:yyyyMMdd}.log");
                Console.WriteLine($"Log file path: {logFilePath}");

                // Configure Serilog with both console and file sinks
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console(
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .WriteTo.File(
                        path: logFilePath,
                        rollingInterval: RollingInterval.Day,
                        shared: true,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        flushToDiskInterval: TimeSpan.FromSeconds(1))
                    .CreateLogger();

                Logger = Log.Logger;
                Logger.Information("Logger initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize logger: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        [SetUp]
        public void SetUp()
        {
            try
            {
                Logger.Information("Test Setup started");
                driver = DriverFactory.GetDriver("chrome");
                Logger.Information("Initialized ChromeDriver");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error during Test Setup");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                Logger.Information("Test TearDown started");
                DriverFactory.QuitDriver(driver);
                Logger.Information("Closed ChromeDriver");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error during Test TearDown");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
