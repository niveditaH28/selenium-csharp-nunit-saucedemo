using NUnit.Framework;
using SauceDemoAutomation.Pages;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        [Test]
        public void CompleteCheckout_ShouldShowConfirmation()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            inventory.OpenCart();

            new CartPage(Driver).ClickCheckout();

            var checkout = new CheckoutPage(Driver);
            checkout.FillInformation("Test", "User", "500001");
            checkout.ClickFinish();

            Assert.That(checkout.GetConfirmation(), Is.EqualTo("Thank you for your order!"));
        }

        [Test]
        public void Checkout_WithoutInformation_ShouldShowError()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            inventory.OpenCart();

            new CartPage(Driver).ClickCheckout();

            var checkout = new CheckoutPage(Driver);
            checkout.ClickContinueOnly();

            Assert.That(checkout.GetErrorMessage(), Does.Contain("First Name is required"));
        }
    }
}
