using OpenQA.Selenium;

namespace SauceDemoAutomation.Pages
{
    public class CartPage : BasePage
    {
        private readonly By cartItems = By.ClassName("cart_item");
        private readonly By itemNames = By.ClassName("inventory_item_name");
        private readonly By checkoutButton = By.Id("checkout");

        public CartPage(IWebDriver driver) : base(driver) { }

        public int GetItemCount()
        {
            // The cart may be empty, so we do not wait for visibility here.
            return Driver.FindElements(cartItems).Count;
        }

        public List<string> GetItemNames()
        {
            WaitForVisible(itemNames);
            return Driver.FindElements(itemNames).Select(e => e.Text).ToList();
        }

        public void ClickCheckout() => Click(checkoutButton);
    }
}
