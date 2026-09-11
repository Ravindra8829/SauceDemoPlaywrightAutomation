using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class CheckoutOverviewPage
{
    private readonly IPage _page;

    private readonly ILocator _productNames;
    private readonly ILocator _finishButton;

    public CheckoutOverviewPage(IPage page)
    {
        _page = page;

        _productNames = _page.Locator("[data-test='inventory-item-name']");
        _finishButton = _page.Locator("[data-test='finish']");
    }

    public async Task<bool> IsProductPresentAsync(string productName)
    {
        var product = _productNames
            .Filter(new LocatorFilterOptions { HasText = productName });

        await product.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible
        });

        return await product.IsVisibleAsync();
    }

    public async Task FinishAsync()
    {
        await _finishButton.ClickAsync();

        await _page.WaitForURLAsync("**/checkout-complete.html");
    }
}