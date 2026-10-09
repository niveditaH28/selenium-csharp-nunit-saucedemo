# selenium-csharp-nunit-saucedemo

# SauceDemo UI Automation (C# + Selenium + NUnit)

Hi, I'm Nivedita Hirge, and this is my test automation project for learning and practising QA automation. I picked [SauceDemo](https://www.saucedemo.com), a demo online store built for testing practice, and wrote automated tests for the main things a customer does: logging in, browsing products, adding items to the cart, and checking out.

I built it to get hands-on with the tools used in real QA teams: Selenium WebDriver, C#, and NUnit. I also wanted to learn how to structure a test project properly instead of dumping everything into one file.

## What it tests

- **Login:** valid login, locked-out user, wrong username or password, empty fields, and logout
- **Products page:** sorting by price (low to high and high to low)
- **Cart:** adding one or two items, removing an item, and checking the cart page
- **Checkout:** a full purchase from start to finish, and the error shown when the form is left empty

That's 14 automated tests in total.

## How it's built

- Page Object Model. Each page of the website has its own class (`LoginPage`, `InventoryPage`, `CartPage`, `CheckoutPage`). If the website changes, I only have to fix one place instead of every test.
- Explicit waits. The tests wait for elements to actually appear instead of using fixed `Sleep` delays, which keeps them faster and less flaky.
- Data-driven tests. The invalid login test runs three times with different data using NUnit's `[TestCase]`.
- Screenshots on failure. If a test fails, it saves a screenshot so I can see what went wrong.
- Headless mode. The tests can run without opening a visible browser.

## Project structure

```
csharp-nunit-saucedemo/
├── Pages/    page classes (locators and actions)
├── Tests/    test classes (the actual test cases)
└── SauceDemoAutomation.csproj
```

## Tools used

C#, .NET 10, Selenium WebDriver 4, NUnit 4, Google Chrome, Git and GitHub, VS Code

## How to run it

You'll need the .NET 10 SDK and Google Chrome installed.

```bash
git clone https://github.com/<your-username>/selenium-csharp-nunit-saucedemo.git
cd selenium-csharp-nunit-saucedemo
dotnet restore
dotnet test
```

To run without a visible browser window:

```powershell
$env:HEADLESS="true"; dotnet test
```

(On Mac or Linux: `HEADLESS=true dotnet test`)

Chrome will open and close for each test, and the full run takes about 1.5 minutes.

## What I learned

- How to structure an automation framework with the Page Object Model
- Why explicit waits are better than fixed delays
- How to write clear assertions and data-driven tests
- How to debug a failing test using error messages and screenshots
- How to use Git and GitHub to keep my work organised

## What I want to add next

- HTML test reports (Allure or ExtentReports)
- Running tests automatically with GitHub Actions
- A config file for the URL and test data
- API tests with Postman

## About me

I'm a Fresher from Mysore, looking for a Software Testing Engineer role. You can find me on [LinkedIn](https://linkedin.com/in/nivedita-hirge) or at niveditahirge@gmail.com.
