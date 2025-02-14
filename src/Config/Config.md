# WebDriver Configuration Settings

## TimeoutInSeconds
- Purpose: Maximum time to wait for elements to be ready
- Default: 30 seconds
- Usage: Used by WebDriverWait in BasePage
- Impact: Affects how long tests will wait before failing

## PollingIntervalInSeconds
- Purpose: Frequency of checking element status
- Default: 0.5 seconds (500ms)
- Usage: Controls WebDriverWait polling frequency
- Impact: Affects CPU usage and test responsiveness