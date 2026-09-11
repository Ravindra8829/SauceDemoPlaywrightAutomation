using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class CartPage
{
    private readonly IPage _page;

    private readonly ILocator _cartBadge;
    private readonly ILocator _productNames;
    private readonly ILocator _checkoutButton;

    public CartPage(IPage page)
    {
        _page = page;

        _cartBadge = _page.Locator("[data-test='shopping-cart-badge']");
        _productNames = _page.Locator("[data-test='inventory-item-name']");
        _checkoutButton = _page.Locator("[data-test='checkout']");
    }

    public async Task<int> GetCartCountAsync()
    {
        var count = await _cartBadge.InnerTextAsync();
        return int.Parse(count);
    }

    public async Task RemoveProductAsync(string productName)
    {
        var slug = productName
            .ToLowerInvariant()
            .Replace(" ", "-");

        await _page
            .Locator($"[data-test='remove-{slug}']")
            .ClickAsync();
    }

    public async Task<bool> IsProductPresentAsync(string productName)
    {
        return await _productNames
            .Filter(new LocatorFilterOptions { HasText = productName })
            .IsVisibleAsync();
    }

    public async Task CheckoutAsync()
    {
        await _checkoutButton.ClickAsync();
    }
}