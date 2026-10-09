using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoAutomation.Pages
{
    // Parent of all page classes. Holds the driver and reusable actions with EXPLICIT WAITS.
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Waits until the element exists AND is displayed, then returns it.
        protected IWebElement WaitForVisible(By locator) =>
            Wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed ? el : null;
            });

        protected void Type(By locator, string text)
        {
            var el = WaitForVisible(locator);
            el.Clear();
            el.SendKeys(text);
        }

        protected void Click(By locator) => WaitForVisible(locator).Click();
        protected string GetText(By locator) => WaitForVisible(locator).Text;

        protected bool IsDisplayed(By locator)
        {
            try { return Driver.FindElement(locator).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
