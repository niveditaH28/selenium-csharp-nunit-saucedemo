using NUnit.Framework;
using SauceDemoAutomation.Pages;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void ValidLogin_ShouldOpenProductsPage()
        {
            var inventory = LoginAsStandardUser();
            Assert.That(inventory.GetTitle(), Is.EqualTo("Products"));
        }

        [Test]
        public void LockedOutUser_ShouldShowError()
        {
            var login = new LoginPage(Driver);
            login.Open();
            login.Login("locked_out_user", "secret_sauce");
            Assert.That(login.GetErrorMessage(), Does.Contain("locked out"));
        }

        // Data-driven: the same test runs 3 times with different data
        [TestCase("standard_user", "wrong_pass")]
        [TestCase("invalid_user", "secret_sauce")]
        [TestCase("", "")]
        public void InvalidLogin_ShouldShowError(string user, string pass)
        {
            var login = new LoginPage(Driver);
            login.Open();
            login.Login(user, pass);
            Assert.That(login.GetErrorMessage(), Does.Contain("Epic sadface"));
        }

        [Test]
        public void Logout_ShouldReturnToLoginPage()
        {
            var inventory = LoginAsStandardUser();
            inventory.Logout();
            Assert.That(Driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}
