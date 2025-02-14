using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestFramework.src.Utilities;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace SeleniumTestFramework.src.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        private static readonly string LogDirectory;

        static TestSetup()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = currentDirectory.Split("bin")[0];
            LogDirectory = Path.Combine(solutionDirectory, "logs");
        }

        [OneTimeSetUp]
        public void InitializeTestRun()
        {
            try
            {
                Console.WriteLine("Initializing test run...");
                if (Directory.Exists(LogDirectory))
                {
                    Directory.Delete(LogDirectory, recursive: true);
                    Console.WriteLine($"Deleted existing log directory: {LogDirectory}");
                }

                Directory.CreateDirectory(LogDirectory);
                Console.WriteLine($"Created new log directory: {LogDirectory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to manage log directory: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        [OneTimeTearDown]
        public void FinalizeTestRun()
        {
            Console.WriteLine("Test run completed");
        }
    }

    public class BaseTest
    {
        protected IWebDriver driver;
        protected ILogger Logger;
        private int stepNumber;
        private string currentTestName;
        private static readonly string LogDirectory = Path.Combine(
            Directory.GetCurrentDirectory().Split("bin")[0], 
            "logs");

        [SetUp]
        public virtual void SetUp()
        {
            try
            {
                // Get the current test name
                currentTestName = TestContext.CurrentContext.Test.Name;
                string logFilePath = Path.Combine(LogDirectory, $"{currentTestName}_{DateTime.Now:yyyyMMddHHmmss}.log");

                // Configure logger for this test
                Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console(
                        restrictedToMinimumLevel: LogEventLevel.Information,
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .WriteTo.File(
                        path: logFilePath,
                        rollingInterval: RollingInterval.Infinite,
                        shared: true,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        flushToDiskInterval: TimeSpan.FromSeconds(1))
                    .CreateLogger();

                stepNumber = 1;
                LogStep("Starting test setup");
                driver = DriverFactory.GetDriver("chrome");
                LogStep("Initialized ChromeDriver");
                Logger.Information($"Test log file created at: {logFilePath}");
            }
            catch (WebDriverException ex)
            {
                LogTestError(nameof(SetUp), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogTestError(nameof(SetUp), ex);
                throw;
            }
        }

        protected void LogStep(string message)
        {
            Logger?.Information($"Step {stepNumber}: {message}");
            stepNumber++;
        }

        protected void LogTestStart(string testName)
        {
            Logger?.Information("------------------------");
            Logger?.Information($"Starting Test: {testName}");
            Logger?.Information("------------------------");
            stepNumber = 1;
        }

        protected void LogTestEnd(string testName)
        {
            Logger?.Information("------------------------");
            Logger?.Information($"Test Completed: {testName}");
            Logger?.Information("------------------------");
        }

        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                LogStep("Starting test teardown");
                if (driver != null)
                {
                    DriverFactory.QuitDriver(driver);
                    LogStep("Closed ChromeDriver");
                }
            }
            catch (WebDriverException ex)
            {
                LogTestError(nameof(TearDown), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogTestError(nameof(TearDown), ex);
                throw;
            }
            finally
            {
                Logger?.Information($"Test {currentTestName} completed");
                (Logger as IDisposable)?.Dispose();
            }
        }

        protected void LogTestError(string testName, Exception ex)
        {
            if (ex is WebDriverTimeoutException timeoutEx)
            {
                Logger?.Error(timeoutEx, 
                    "Selenium Timeout in {TestName}\nMessage: {ErrorMessage}\nSource: {Source}\nStack Trace: {StackTrace}", 
                    testName, 
                    timeoutEx.Message,
                    timeoutEx.Source,
                    timeoutEx.StackTrace);

                if (timeoutEx.InnerException != null)
                {
                    Logger?.Error("Inner Exception: {InnerException}", timeoutEx.InnerException.Message);
                }
            }
            else if (ex is WebDriverException webDriverEx)
            {
                Logger?.Error(webDriverEx, 
                    "Selenium error in {TestName}\nMessage: {ErrorMessage}\nSource: {Source}\nStack Trace: {StackTrace}", 
                    testName, 
                    webDriverEx.Message,
                    webDriverEx.Source,
                    webDriverEx.StackTrace);

                if (webDriverEx.InnerException != null)
                {
                    Logger?.Error("Inner Exception: {InnerException}", webDriverEx.InnerException.Message);
                }
            }
            else
            {
                Logger?.Error(ex, 
                    "Error in {TestName}\nMessage: {ErrorMessage}\nSource: {Source}\nStack Trace: {StackTrace}", 
                    testName, 
                    ex.Message,
                    ex.Source,
                    ex.StackTrace);

                if (ex.InnerException != null)
                {
                    Logger?.Error("Inner Exception: {InnerException}", ex.InnerException.Message);
                }
            }
        }
    }
}