using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTestFramework.src.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        protected void WaitForElementToBeVisible(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void ClickElement(By locator)
        {
            WaitForElementToBeVisible(locator);
            _driver.FindElement(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            WaitForElementToBeVisible(locator);
            _driver.FindElement(locator).SendKeys(text);
        }
    }
}