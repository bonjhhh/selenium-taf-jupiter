# Selenium Test Automation Framework [Work In Progress]

This is a Selenium-based test automation framework designed to facilitate the creation and execution of automated tests for web applications. The framework leverages NUnit for test management and Serilog for logging.

## Project Structure

<To be updated>

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

## Object-Oriented Design Principles

### Single Responsibility Principle (SRP)

Each class in the framework has a single responsibility:
- **BasePage**: Manages common page interactions and WebDriverWait configuration.
- **ContactPage**: Encapsulates interactions specific to the contact page.
- **HomePage**: Encapsulates interactions specific to the home page.
- **BaseTest**: Manages setup, teardown, and logging for tests.
- **DriverFactory**: Handles WebDriver creation and management.
- **TestDataGenerator**: Generates random test data.

### Open/Closed Principle (OCP)

The framework is designed to be open for extension but closed for modification:
- New page objects can be added by extending the **BasePage** class.
- New tests can be added by extending the **BaseTest** class.
- Configuration settings can be extended by updating **Config.json** and **ConfigurationHelper**.

### Dependency Inversion Principle (DIP)

High-level modules do not depend on low-level modules; both depend on abstractions:
- **BaseTest** depends on **DriverFactory** for WebDriver instances.
- **BasePage** depends on **ConfigurationHelper** for WebDriverWait settings.

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
    dotnet tests

5. Running specific tests:
```sh
    dotnet test --filter "Name=Test_MultipleContact_ValidSubmission_SuccessMessage"

6. Configuration

The framework uses a Config.json file to manage WebDriver settings. The file is located in the Config directory

TimeoutInSeconds: Maximum time to wait for elements to be ready.
PollingIntervalInSeconds: Frequency of checking element status.

```sh
    {
        "WebDriver": {
            "TimeoutInSeconds": 30,
            "PollingIntervalInSeconds": 0.5
        }
    }

7. Logging

The framework uses Serilog for logging. Logs are written to both the console and a file. Each test creates a separate log file in the logs directory.
