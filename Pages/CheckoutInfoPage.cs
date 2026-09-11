using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class CheckoutInfoPage
{
    private readonly IPage _page;

    private readonly ILocator _firstName;
    private readonly ILocator _lastName;
    private readonly ILocator _postalCode;
    private readonly ILocator _continueButton;

    public CheckoutInfoPage(IPage page)
    {
        _page = page;

        _firstName = _page.Locator("[data-test='firstName']");
        _lastName = _page.Locator("[data-test='lastName']");
        _postalCode = _page.Locator("[data-test='postalCode']");
        _continueButton = _page.Locator("[data-test='continue']");
    }

    public async Task FillInformationAsync(
        string firstName,
        string lastName,
        string postalCode)
    {
        await _firstName.FillAsync(firstName);
        await _lastName.FillAsync(lastName);
        await _postalCode.FillAsync(postalCode);
    }

    public async Task ContinueAsync()
    {
        await _continueButton.ClickAsync();
    }
}