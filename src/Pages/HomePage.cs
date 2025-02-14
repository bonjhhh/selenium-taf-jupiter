using OpenQA.Selenium;

namespace SeleniumTestFramework.src.Pages
{
    public class HomePage : BasePage
    {
        private readonly By contactLink = By.CssSelector("a[href='#/contact']");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/");
        }

        public void NavigateToContactPage()
        {
            ClickElement(contactLink);
        }

        public bool VerifyContactLinkLabel()
        {
            var contactLinkElement = _driver.FindElement(contactLink);
            return contactLinkElement.Text.Contains("Contact");
        }
    }
}