# Selenium Test Automation Framework

This project is a test automation framework built using Selenium and C# for the website [Jupiter Cloud](https://jupiter.cloud.planittesting.com/). The framework follows the Page Object Model (POM) design pattern to enhance maintainability and readability of the test code.

## Project Structure

```
SeleniumTestFramework
├── src
│   ├── Pages
│   │   ├── HomePage.cs
│   │   ├── ContactPage.cs
│   │   └── ShopPage.cs
│   ├── Tests
│   │   ├── HomePageTests.cs
│   │   ├── ContactPageTests.cs
│   │   └── ShopPageTests.cs
│   ├── DataProviders
│   │   └── TestData.cs
│   ├── Utilities
│   │   ├── DriverFactory.cs
│   │   └── ConfigReader.cs
│   └── CI_CD
│       └── azure-pipelines.yml
├── SeleniumTestFramework.sln
├── SeleniumTestFramework.csproj
└── README.md
```

## Setup Instructions

1. **Clone the Repository**
   Clone the repository to your local machine using:
   ```
   git clone <repository-url>
   ```

2. **Open the Solution**
   Open the `SeleniumTestFramework.sln` file in your preferred C# IDE.

3. **Install Dependencies**
   Ensure that you have the necessary NuGet packages installed. You can do this by restoring the packages:
   ```
   dotnet restore
   ```

4. **Configure WebDriver**
   Update the `ConfigReader.cs` file to specify the WebDriver settings, including the browser type and path to the WebDriver executable.

5. **Run Tests**
   You can run the tests using the test runner in your IDE or by using the command line:
   ```
   dotnet test
   ```

## Usage Guidelines

- **Page Classes**: Each page of the application has a corresponding class in the `Pages` directory. These classes contain methods for interacting with the elements on the page.
  
- **Test Classes**: The `Tests` directory contains test classes that implement various test cases for each page. Each test class should follow the naming convention `<PageName>Tests`.

- **Data Providers**: The `DataProviders` directory contains classes that provide test data for the tests. This helps in maintaining a clean separation between test logic and test data.

- **Utilities**: The `Utilities` directory contains helper classes such as `DriverFactory` for managing WebDriver instances and `ConfigReader` for reading configuration settings.

- **CI/CD Configuration**: The `CI_CD` directory contains the `azure-pipelines.yml` file, which defines the CI/CD pipeline for building and deploying the project.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.