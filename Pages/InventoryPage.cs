using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoAutomation.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly By title = By.ClassName("title");
        private readonly By backpackAddBtn = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By bikeLightAddBtn = By.Id("add-to-cart-sauce-labs-bike-light");
        private readonly By backpackRemoveBtn = By.Id("remove-sauce-labs-backpack");
        private readonly By cartBadge = By.ClassName("shopping_cart_badge");
        private readonly By cartLink = By.ClassName("shopping_cart_link");
        private readonly By sortDropdown = By.ClassName("product_sort_container");
        private readonly By itemPrices = By.ClassName("inventory_item_price");
        private readonly By menuButton = By.Id("react-burger-menu-btn");
        private readonly By logoutLink = By.Id("logout_sidebar_link");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        public string GetTitle() => GetText(title);
        public void AddBackpackToCart() => Click(backpackAddBtn);
        public void AddBikeLightToCart() => Click(bikeLightAddBtn);
        public void RemoveBackpack() => Click(backpackRemoveBtn);
        public string GetCartCount() => GetText(cartBadge);
        public bool IsCartBadgeVisible() => IsDisplayed(cartBadge);
        public void OpenCart() => Click(cartLink);

        public void SortBy(string visibleText)
        {
            new SelectElement(WaitForVisible(sortDropdown)).SelectByText(visibleText);
        }

        public List<double> GetPrices()
        {
            WaitForVisible(itemPrices);
            return Driver.FindElements(itemPrices)
                .Select(e => double.Parse(e.Text.Replace("$", "")))
                .ToList();
        }

        public void Logout()
        {
            Click(menuButton);
            Click(logoutLink);
        }
    }
}
