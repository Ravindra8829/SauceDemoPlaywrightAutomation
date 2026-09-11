using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class ProductsPage
{
    private readonly IPage _page;

    private readonly ILocator _backpackAddToCart;
    private readonly ILocator _bikeLightAddToCart;
    private readonly ILocator _shoppingCart;
    private readonly ILocator _cartBadge;

    public ProductsPage(IPage page)
    {
        _page = page;

        _backpackAddToCart = _page.Locator("[data-test='add-to-cart-sauce-labs-backpack']");
        _bikeLightAddToCart = _page.Locator("[data-test='add-to-cart-sauce-labs-bike-light']");
        _shoppingCart = _page.Locator("[data-test='shopping-cart-link']");
        _cartBadge = _page.Locator("[data-test='shopping-cart-badge']");
    }

    public async Task AddBackpackAsync()
    {
        await _backpackAddToCart.ClickAsync();
    }

    public async Task AddBikeLightAsync()
    {
        await _bikeLightAddToCart.ClickAsync();
    }

    public async Task<int> GetCartCountAsync()
    {
        var count = await _cartBadge.InnerTextAsync();
        return int.Parse(count);
    }

    public async Task OpenCartAsync()
    {
        await _shoppingCart.ClickAsync();
    }
}