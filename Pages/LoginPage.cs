using OpenQA.Selenium;

namespace SauceDemoAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By username = By.Id("user-name");
        private readonly By password = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessage = By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Open() => Driver.Navigate().GoToUrl("https://www.saucedemo.com");

        public void Login(string user, string pass)
        {
            Type(username, user);
            Type(password, pass);
            Click(loginButton);
        }

        public string GetErrorMessage() => GetText(errorMessage);
    }
}
