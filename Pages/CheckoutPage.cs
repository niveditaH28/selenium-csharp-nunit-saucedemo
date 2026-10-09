using OpenQA.Selenium;

namespace SauceDemoAutomation.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly By firstName = By.Id("first-name");
        private readonly By lastName = By.Id("last-name");
        private readonly By postalCode = By.Id("postal-code");
        private readonly By continueButton = By.Id("continue");
        private readonly By finishButton = By.Id("finish");
        private readonly By completeHeader = By.ClassName("complete-header");
        private readonly By errorMessage = By.CssSelector("[data-test='error']");

        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public void FillInformation(string first, string last, string zip)
        {
            Type(firstName, first);
            Type(lastName, last);
            Type(postalCode, zip);
            Click(continueButton);
        }

        public void ClickContinueOnly() => Click(continueButton);
        public void ClickFinish() => Click(finishButton);
        public string GetConfirmation() => GetText(completeHeader);
        public string GetErrorMessage() => GetText(errorMessage);
    }
}
