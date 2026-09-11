using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class CartPage
{
    private readonly IPage _page;

    private readonly ILocator _cartBadge;
    private readonly ILocator _bikeLightRemoveButton;
    private readonly ILocator _backpackRemoveButton;
    private readonly ILocator _productNames;
    private readonly ILocator _checkoutButton;

    public CartPage(IPage page)
    {
        _page = page;

        _cartBadge = _page.Locator("[data-test='shopping-cart-badge']");
        _bikeLightRemoveButton = _page.Locator("[data-test='remove-sauce-labs-bike-light']");
        _backpackRemoveButton = _page.Locator("[data-test='remove-sauce-labs-backpack']");
        _productNames = _page.Locator("[data-test='inventory-item-name']");
        _checkoutButton = _page.Locator("[data-test='checkout']");
    }

    public async Task<int> GetCartCountAsync()
    {
        var count = await _cartBadge.InnerTextAsync();
        return int.Parse(count);
    }

    public async Task RemoveBikeLightAsync()
    {
        await _bikeLightRemoveButton.ClickAsync();
    }

    public async Task RemoveBackpackAsync()
    {
        await _backpackRemoveButton.ClickAsync();
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