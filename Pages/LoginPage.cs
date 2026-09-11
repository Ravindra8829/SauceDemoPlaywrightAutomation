using Microsoft.Playwright;

namespace SauceDemoPlaywrightAutomation.Pages;

public class LoginPage
{
    private readonly IPage _page;

    private readonly ILocator _username;
    private readonly ILocator _password;
    private readonly ILocator _loginButton;

    public LoginPage(IPage page)
    {
        _page = page;

        _username = _page.Locator("[data-test='username']");
        _password = _page.Locator("[data-test='password']");
        _loginButton = _page.Locator("[data-test='login-button']");
    }

    public async Task LoginAsync(string username, string password)
    {
        await _username.FillAsync(username);
        await _password.FillAsync(password);
        await _loginButton.ClickAsync();
    }
}