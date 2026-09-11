using Microsoft.Playwright;
using NUnit.Framework;
using SauceDemoPlaywrightAutomation.Pages;

namespace SauceDemoPlaywrightAutomation.Tests;

public class CheckoutTest
{
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IPage _page = null!;

    [SetUp]
    public async Task SetUp()
    {
        _playwright = await Playwright.CreateAsync();

        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Channel = "chrome",
            Headless = false
        });

        _page = await _browser.NewPageAsync();
    }

    [Test]
    public async Task CompleteCheckout()
    {
        // Open SauceDemo
        await _page.GotoAsync("https://www.saucedemo.com/");

        // Login
        var loginPage = new LoginPage(_page);
        await loginPage.LoginAsync("visual_user", "secret_sauce");

        // Add two products
        var productsPage = new ProductsPage(_page);

        await productsPage.AddBackpackAsync();
        await productsPage.AddBikeLightAsync();

        // Verify cart has 2 products
        var cartCount = await productsPage.GetCartCountAsync();
        Assert.That(cartCount, Is.EqualTo(2));

        // Open cart
        await productsPage.OpenCartAsync();

        // Remove Bike Light
        var cartPage = new CartPage(_page);
        await cartPage.RemoveBikeLightAsync();

        // Verify cart has 1 product
        cartCount = await cartPage.GetCartCountAsync();
        Assert.That(cartCount, Is.EqualTo(1));

        // Verify Backpack is the remaining product
        var backpackInCart =
            await cartPage.IsProductPresentAsync("Sauce Labs Backpack");

        Assert.That(backpackInCart, Is.True);

        // Checkout
        await cartPage.CheckoutAsync();

        // Fill checkout information
        var checkoutInfoPage = new CheckoutInfoPage(_page);

        await checkoutInfoPage.FillInformationAsync(
            "Ravindra",
            "Suthar",
            "411001"
        );

        await checkoutInfoPage.ContinueAsync();

        // Checkout Overview
        var checkoutOverviewPage = new CheckoutOverviewPage(_page);

        // Verify Backpack is displayed on Overview
        var backpackOnOverview =
            await checkoutOverviewPage.IsProductPresentAsync("Sauce Labs Backpack");

        Assert.That(backpackOnOverview, Is.True);

        // Finish checkout
        await checkoutOverviewPage.FinishAsync();

        // Checkout Complete
        var checkoutCompletePage = new CheckoutCompletePage(_page);

        // Verify Checkout: Complete!
        var checkoutComplete =
            await checkoutCompletePage.IsCheckoutCompleteAsync();

        Assert.That(checkoutComplete, Is.True);

        // Verify confirmation message
        var confirmationMessage =
            await checkoutCompletePage.IsConfirmationMessageVisibleAsync();

        Assert.That(confirmationMessage, Is.True);
    }

    [TearDown]
    public async Task TearDown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}