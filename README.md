# Selenium Test Automation Framework [Work In Progress]

This is a Selenium-based test automation framework designed to facilitate the creation and execution of automated tests for web applications. The framework leverages NUnit for test management and Serilog for logging.

## Project Structure [To be updated]

## Key Components

### Config

- **Config.json**: Contains configuration settings for WebDriver, such as timeout and polling interval.

### Data

- **ContactData.cs**: Holds data structures for contact form submissions.

### Pages

- **BasePage.cs**: The base class for all page objects, providing common functionality and WebDriverWait configuration.
- **ContactPage.cs**: Represents the contact page and encapsulates interactions with its elements.
- **HomePage.cs**: Represents the home page and encapsulates interactions with its elements.

### Tests

- **BaseTest.cs**: The base class for all test classes, providing setup and teardown methods, and logging functionality.
- **ContactPageTests.cs**: Contains test cases for the contact page, including tests for empty fields and valid submissions.

### Utilities

- **ConfigurationHelper.cs**: Provides methods to read configuration settings from Config.json.
- **DriverFactory.cs**: Creates and manages WebDriver instances.
- **TestDataGenerator.cs**: Generates random test data for use in tests.

## Getting Started

### Prerequisites

- .NET SDK 8.0 or later
- ChromeDriver

### Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/selenium-taf-jupiter.git
   cd selenium-taf-jupiter


2. Restore dependencies:   
   ```sh
    dotnet restore

3. Build the project:   
   ```sh
    dotnet build

4. Running All Tests:   
   ```sh
    dotnet build

5. Running specific tests:
   ```sh
    dotnet test --filter "Name=Test_MultipleContact_ValidSubmission_SuccessMessage"

6. Configuration

The framework uses a Config.json file to manage WebDriver settings. The file is located in the Config directory. Samples:

TimeoutInSeconds: Maximum time to wait for elements to be ready.
PollingIntervalInSeconds: Frequency of checking element status.


7. Logging

The framework uses Serilog for logging. Logs are written to both the console and a file. Each test creates a separate log file in the logs directory.