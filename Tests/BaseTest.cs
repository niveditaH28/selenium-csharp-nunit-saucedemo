using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoAutomation.Pages;

namespace SauceDemoAutomation.Tests
{
    // Every test class inherits this. [SetUp] runs BEFORE each test, [TearDown] AFTER each test.
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            // Run without a visible browser when HEADLESS=true (useful for CI/servers)
            if (Environment.GetEnvironmentVariable("HEADLESS") == "true")
                options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");

            Driver = new ChromeDriver(options);   // Selenium Manager downloads chromedriver automatically
            if (Environment.GetEnvironmentVariable("HEADLESS") != "true")
                Driver.Manage().Window.Maximize();
        }

        // Shared helper: open site and log in
        protected InventoryPage LoginAsStandardUser()
        {
            var login = new LoginPage(Driver);
            login.Open();
            login.Login("standard_user", "secret_sauce");
            return new InventoryPage(Driver);
        }

        [TearDown]
        public void Teardown()
        {
            // Screenshot only when a test fails, saved in the test output folder
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var shot = ((ITakesScreenshot)Driver).GetScreenshot();
                var name = $"{TestContext.CurrentContext.Test.Name}.png"
                    .Replace("\"", "").Replace(",", "_");
                shot.SaveAsFile(Path.Combine(TestContext.CurrentContext.WorkDirectory, name));
            }
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
