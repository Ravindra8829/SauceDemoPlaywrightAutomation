using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class ProductsPage
{
    private readonly IPage _page;

    private readonly ILocator _shoppingCart;
    private readonly ILocator _cartBadge;

    public ProductsPage(IPage page)
    {
        _page = page;

        _shoppingCart = _page.Locator("[data-test='shopping-cart-link']");
        _cartBadge = _page.Locator("[data-test='shopping-cart-badge']");
    }

    public async Task AddProductAsync(string productName)
    {
        var slug = productName
            .ToLowerInvariant()
            .Replace(" ", "-");

        await _page
            .Locator($"[data-test='add-to-cart-{slug}']")
            .ClickAsync();
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