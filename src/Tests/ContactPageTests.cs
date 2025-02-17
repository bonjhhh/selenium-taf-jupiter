using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestFramework.src.Pages;
using SeleniumTestFramework.src.Data;
using SeleniumTestFramework.src.Utilities;
using System;

namespace SeleniumTestFramework.src.Tests
{
    [TestFixture]
    public class ContactPageTests : BaseTest
    {
        private ContactPage contactPage;
        private HomePage homePage;
        private ContactData contactData;

        [SetUp]
        public override void SetUp()
        {
            try
            {
                base.SetUp();
                LogStep("Setting up test dependencies");
                homePage = new HomePage(driver);
                contactPage = new ContactPage(driver);
                contactData = new ContactData();

                LogStep("Navigating to home page");
                homePage.NavigateToHomePage();
                LogStep("Test setup completed");
            }
            catch (Exception ex)
            {
                LogTestError(nameof(SetUp), ex);
                throw;
            }
        }

        [Test]
        public void Test_EmptyFields_ErrorMessage()
        {
            try
            {
                LogTestStart(nameof(Test_EmptyFields_ErrorMessage));

                LogStep("Navigating to Contact page");
                homePage.NavigateToContactPage();

                LogStep("Clicking submit button with empty fields");
                contactPage.ClickSubmitButton();

                LogStep("Getting error messages");
                string feedbackError = contactPage.GetFeedbackErrorMessage();
                string forenameError = contactPage.GetForenameErrorMessage();
                string emailError = contactPage.GetEmailErrorMessage();
                string messageError = contactPage.GetMessageErrorMessage();

                LogStep("Verifying error messages");
                Logger.Information("Feedback Error: {FeedbackError}", feedbackError);
                Logger.Information("Forename Error: {ForenameError}", forenameError);
                Logger.Information("Email Error: {EmailError}", emailError);
                Logger.Information("Message Error: {MessageError}", messageError);

                Assert.Multiple(() =>
                {
                    Assert.That(feedbackError, Is.EqualTo("We welcome your feedback - but we won't get it unless you complete the form correctly."));
                    Assert.That(forenameError, Is.EqualTo("Forename is required"));
                    Assert.That(emailError, Is.EqualTo("Email is required"));
                    Assert.That(messageError, Is.EqualTo("Message is required"));
                });

                LogTestEnd(nameof(Test_EmptyFields_ErrorMessage));
            }
            catch (WebDriverTimeoutException timeoutEx)
            {
                LogStep("FAILED: Timeout while getting error messages");
                LogTestError(nameof(Test_EmptyFields_ErrorMessage), timeoutEx);
                throw;
            }
            catch (Exception ex)
            {
                LogStep("FAILED: Unexpected error during test execution");
                LogTestError(nameof(Test_EmptyFields_ErrorMessage), ex);
                throw;
            }
        }

        [Test]        
        public void Test_OneContact_ValidSubmission_SuccessMessage()
        {
            try
            {
              
                LogTestStart(nameof(Test_OneContact_ValidSubmission_SuccessMessage));
                LogStep("Navigating to Contact page");
                homePage.NavigateToContactPage();

                LogStep("Populating mandatory fields");
                contactPage.PopulateMandatoryFields(
                    contactData.ValidForm.Forename,
                    contactData.ValidForm.Surname,
                    contactData.ValidForm.Email,
                    contactData.ValidForm.Telephone,
                    contactData.ValidForm.Message
                );

                LogStep("Clicking submit button");
                contactPage.ClickSubmitButton();

                LogStep("Getting success message");
                string successMessage = contactPage.GetSuccessFeedbackMessage();
                Logger.Information("Success Message: {SuccessMessage}", successMessage);

                LogStep("Verifying success message");
                Assert.That(successMessage, 
                    Is.EqualTo($"Thanks {contactData.ValidForm.Forename}, we appreciate your feedback."));

                LogTestEnd(nameof(Test_OneContact_ValidSubmission_SuccessMessage));
            }
            catch (WebDriverTimeoutException timeoutEx)
            {
                LogStep("FAILED: Timeout while waiting for success message");
                LogTestError($"{nameof(Test_OneContact_ValidSubmission_SuccessMessage)} - Iteration {TestContext.CurrentContext.CurrentRepeatCount + 1}", timeoutEx);
                throw;
            }
            catch (Exception ex)
            {
                LogStep("FAILED: Unexpected error during test execution");
                LogTestError($"{nameof(Test_OneContact_ValidSubmission_SuccessMessage)} - Iteration {TestContext.CurrentContext.CurrentRepeatCount + 1}", ex);
                throw;
            }
        }

        [Test]
        [Repeat(5)]
        public void Test_MultipleContact_ValidSubmission_SuccessMessage()
        {
            try
            {
                var testIteration = TestContext.CurrentContext.CurrentRepeatCount + 1;
                LogTestStart($"{nameof(Test_MultipleContact_ValidSubmission_SuccessMessage)} - Iteration {testIteration}");

                var (forename, surname, email, phone, message) = TestDataGenerator.GenerateRandomContactData();
                
                Logger.Information("Generated test data for iteration {Iteration}:", testIteration);
                Logger.Information("Forename: {Forename}", forename);
                Logger.Information("Surname: {Surname}", surname);
                Logger.Information("Email: {Email}", email);
                Logger.Information("Phone: {Phone}", phone);
                Logger.Information("Message: {Message}", message);

                LogStep("Navigating to Contact page");
                homePage.NavigateToContactPage();

                LogStep("Populating mandatory fields with random data");
                contactPage.PopulateMandatoryFields(
                    forename,
                    surname,
                    email,
                    phone,
                    message
                );

                LogStep("Clicking submit button");
                contactPage.ClickSubmitButton();

                LogStep("Getting success message");
                string successMessage = contactPage.GetSuccessFeedbackMessage();
                Logger.Information("Success Message: {SuccessMessage}", successMessage);

                LogStep("Verifying success message");
                Assert.That(successMessage, 
                    Is.EqualTo($"Thanks {forename}, we appreciate your feedback."),
                    "Success message does not match expected format");

                LogTestEnd($"{nameof(Test_MultipleContact_ValidSubmission_SuccessMessage)} - Iteration {testIteration}");
            }
            catch (WebDriverTimeoutException timeoutEx)
            {
                LogStep("FAILED: Timeout while waiting for success message");
                LogTestError($"{nameof(Test_MultipleContact_ValidSubmission_SuccessMessage)} - Iteration {TestContext.CurrentContext.CurrentRepeatCount + 1}", timeoutEx);
                throw;
            }
            catch (Exception ex)
            {
                LogStep("FAILED: Unexpected error during test execution");
                LogTestError($"{nameof(Test_MultipleContact_ValidSubmission_SuccessMessage)} - Iteration {TestContext.CurrentContext.CurrentRepeatCount + 1}", ex);
                throw;
            }
        }

        [TearDown]
        public override void TearDown()
        {
            try
            {
                base.TearDown();
            }
            catch (Exception ex)
            {
                LogTestError(nameof(TearDown), ex);
                throw;
            }
        }
    }
}