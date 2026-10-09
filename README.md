# SauceDemo UI Automation - C# | Selenium WebDriver | NUnit

Automated UI tests for https://www.saucedemo.com using the Page Object Model.

## Tech stack
C#, .NET 8, Selenium WebDriver 4, NUnit 4

## Modules covered
Login (valid, invalid, locked-out, logout) | Inventory (sorting) | Cart (add/remove) | Checkout (happy path, validation)

## Key features
- Page Object Model (Pages/ and Tests/ separated)
- Explicit waits (no Thread.Sleep)
- Data-driven tests with [TestCase]
- Screenshot on failure
- Headless mode via `HEADLESS=true`

## Run
```bash
dotnet restore
dotnet test
HEADLESS=true dotnet test      # headless (Windows PowerShell: $env:HEADLESS="true"; dotnet test)
```
Requirements: .NET 8 SDK and Google Chrome.
