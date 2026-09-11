using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class CheckoutCompletePage
{
    private readonly IPage _page;

    private readonly ILocator _title;
    private readonly ILocator _confirmationMessage;

    public CheckoutCompletePage(IPage page)
    {
        _page = page;

        _title = _page.Locator("[data-test='title']");
        _confirmationMessage = _page.Locator("[data-test='complete-text']");
    }

    public async Task<bool> IsCheckoutCompleteAsync()
    {
        await _title.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible
        });

        var titleText = await _title.InnerTextAsync();

        return titleText.Trim() == "Checkout: Complete!";
    }

    public async Task<bool> IsConfirmationMessageVisibleAsync()
    {
        await _confirmationMessage.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible
        });

        var messageText = await _confirmationMessage.InnerTextAsync();

        return messageText.Contains("Your order has been dispatched");
    }
}