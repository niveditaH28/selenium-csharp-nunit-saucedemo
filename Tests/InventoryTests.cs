using NUnit.Framework;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTest
    {
        [Test]
        public void SortPriceLowToHigh_ShouldOrderAscending()
        {
            var inventory = LoginAsStandardUser();
            inventory.SortBy("Price (low to high)");

            var prices = inventory.GetPrices();
            Assert.That(prices, Is.Ordered.Ascending);
        }

        [Test]
        public void SortPriceHighToLow_ShouldOrderDescending()
        {
            var inventory = LoginAsStandardUser();
            inventory.SortBy("Price (high to low)");

            var prices = inventory.GetPrices();
            Assert.That(prices, Is.Ordered.Descending);
        }
    }
}
