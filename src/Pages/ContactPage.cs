using OpenQA.Selenium;

namespace SeleniumTestFramework.src.Pages
{
    public class ContactPage : BasePage
    {
        // Locators
        private readonly By forenameField = By.Id("forename");
        private readonly By surnameField = By.Id("surname");
        private readonly By emailField = By.Id("email");
        private readonly By telephoneField = By.Id("telephone");
        private readonly By messageField = By.Id("message");
        private readonly By submitButton = By.XPath("//a[contains(@class, 'btn-contact') and contains(@class, 'btn-primary') and text()='Submit']");
        private readonly By successMessage = By.CssSelector(".alert.alert-success");
        private readonly By errorMessages = By.CssSelector(".alert.alert-error");
        private readonly By feedbackErrorMessage = By.XPath("//div[contains(@class, 'alert-error') and contains(@class, 'ng-scope') and contains(., 'We welcome your feedback')]");
        private readonly By forenameErrorMessage = By.CssSelector("span.help-inline.ng-scope#forename-err");
        private readonly By emailErrorMessage = By.CssSelector("span.help-inline.ng-scope#email-err");
        private readonly By messageErrorMessage = By.CssSelector("span.help-inline.ng-scope#message-err");
        private readonly By infoMessage = By.XPath("//div[contains(@class, 'alert-info') and contains(@class, 'ng-scope') and contains(., 'We welcome your feedback - tell it how it is.')]");
        private readonly By successFeedbackMessage = By.CssSelector("div.alert.alert-success");

        public ContactPage(IWebDriver driver) : base(driver) { }

        public void ClickSubmitButton()
        {
            ClickElement(submitButton);
        }

        public bool VerifyErrorMessages()
        {
            return _driver.FindElements(errorMessages).Count > 0;
        }

        public string GetFeedbackErrorMessage()
        {
            return _driver.FindElement(feedbackErrorMessage).Text;
        }

        public string GetForenameErrorMessage()
        {
            return _driver.FindElement(forenameErrorMessage).Text;
        }

        public string GetEmailErrorMessage()
        {
            return _driver.FindElement(emailErrorMessage).Text;
        }

        public string GetMessageErrorMessage()
        {
            return _driver.FindElement(messageErrorMessage).Text;
        }

        public string GetInfoMessage()
        {
            return _driver.FindElement(infoMessage).Text;
        }

        public string GetSuccessFeedbackMessage()
        {
            WaitForElementToBeVisible(successFeedbackMessage);
            return _driver.FindElement(successFeedbackMessage).Text;
        }

        public void PopulateMandatoryFields(string forename, string surname, string email, string telephone, string message)
        {
            EnterText(forenameField, forename);
            EnterText(surnameField, surname);
            EnterText(emailField, email);
            EnterText(telephoneField, telephone);
            EnterText(messageField, message);
        }

        public bool ValidateSuccessMessage()
        {
            return _driver.FindElements(successMessage).Count > 0;
        }

        public bool VerifyAllErrorMessages()
        {
            return VerifyFeedbackErrorMessage() &&
                   VerifyForenameErrorMessage() &&
                   VerifyEmailErrorMessage() &&
                   VerifyMessageErrorMessage();
        }

        public bool VerifyFeedbackErrorMessage()
        {
            var feedbackMessage = GetFeedbackErrorMessage();
            return feedbackMessage.Contains("We welcome your feedback - but we won't get it unless you complete the form correctly.");
        }

        public bool VerifyForenameErrorMessage()
        {
            var forenameError = GetForenameErrorMessage();
            return forenameError.Contains("Forename is required");
        }

        public bool VerifyEmailErrorMessage()
        {
            var emailError = GetEmailErrorMessage();
            return emailError.Contains("Email is required");
        }

        public bool VerifyMessageErrorMessage()
        {
            var messageError = GetMessageErrorMessage();
            return messageError.Contains("Message is required");
        }
    }
}