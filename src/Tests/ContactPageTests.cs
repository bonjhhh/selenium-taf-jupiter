using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestFramework.src.Pages;
using SeleniumTestFramework.src.Utilities;
using SeleniumTestFramework.src.Data;

namespace SeleniumTestFramework.src.Tests
{
    [TestFixture]
    public class ContactPageTests : BaseTest
    {
        private ContactPage contactPage;
        private HomePage homePage;
        private ContactData contactData;

        [SetUp]
        public void TestSetUp()
        {
            Logger.Information("Setting up the test.");
            homePage = new HomePage(driver);
            contactPage = new ContactPage(driver);
            contactData = new ContactData();
            homePage.NavigateToHomePage();
            Logger.Information("Navigated to home page.");
        }

        [Test]
        public void Test_EmptyFields_ErrorMessage()
        {
            Logger.Information("Starting Test_EmptyFields_ErrorMessage.");
            homePage.NavigateToContactPage();
            Logger.Information("Navigated to contact page.");
            contactPage.ClickSubmitButton();
            Logger.Information("Clicked submit button.");

            string feedbackError = contactPage.GetFeedbackErrorMessage();
            string forenameError = contactPage.GetForenameErrorMessage();
            string emailError = contactPage.GetEmailErrorMessage();
            string messageError = contactPage.GetMessageErrorMessage();

            Logger.Information($"Feedback Error: {feedbackError}");
            Logger.Information($"Forename Error: {forenameError}");
            Logger.Information($"Email Error: {emailError}");
            Logger.Information($"Message Error: {messageError}");

            Assert.That(feedbackError, Is.EqualTo("We welcome your feedback - but we won't get it unless you complete the form correctly."));
            Assert.That(forenameError, Is.EqualTo("Forename is required"));
            Assert.That(emailError, Is.EqualTo("Email is required"));
            Assert.That(messageError, Is.EqualTo("Message is required"));
            Logger.Information("Test_EmptyFields_ErrorMessage completed.");
        }

        [Test]
        public void Test_ValidSubmission_SuccessMessage()
        {
            Logger.Information("Starting Test_ValidSubmission_SuccessMessage.");
            homePage.NavigateToContactPage();
            Logger.Information("Navigated to contact page.");
            contactPage.PopulateMandatoryFields(contactData.ValidForm.Forename, contactData.ValidForm.Surname, contactData.ValidForm.Email, contactData.ValidForm.Telephone, contactData.ValidForm.Message);
            Logger.Information("Populated mandatory fields.");
            contactPage.ClickSubmitButton();
            Logger.Information("Clicked submit button.");

            string successMessage = contactPage.GetSuccessFeedbackMessage();
            Logger.Information($"Success Message: {successMessage}");

            Assert.That(successMessage, Is.EqualTo($"Thanks {contactData.ValidForm.Forename}, we appreciate your feedback."));
            Logger.Information("Test_ValidSubmission_SuccessMessage completed.");
        }
    }
}