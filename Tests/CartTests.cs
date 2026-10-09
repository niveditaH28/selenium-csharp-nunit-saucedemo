using NUnit.Framework;
using SauceDemoAutomation.Pages;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        [Test]
        public void AddItem_ShouldUpdateCartBadge()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            Assert.That(inventory.GetCartCount(), Is.EqualTo("1"));
        }

        [Test]
        public void AddTwoItems_BadgeShouldShowTwo()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            inventory.AddBikeLightToCart();
            Assert.That(inventory.GetCartCount(), Is.EqualTo("2"));
        }

        [Test]
        public void RemoveItem_ShouldHideCartBadge()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            inventory.RemoveBackpack();
            Assert.That(inventory.IsCartBadgeVisible(), Is.False);
        }

        [Test]
        public void CartPage_ShouldListAddedItem()
        {
            var inventory = LoginAsStandardUser();
            inventory.AddBackpackToCart();
            inventory.OpenCart();

            var cart = new CartPage(Driver);
            Assert.That(cart.GetItemNames(), Does.Contain("Sauce Labs Backpack"));
        }
    }
}
