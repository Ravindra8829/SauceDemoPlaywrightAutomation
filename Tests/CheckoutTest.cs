using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemoPlaywrightAutomation.Pages;

namespace SauceDemoPlaywrightAutomation.Tests;

[TestFixture]
public class CheckoutTests : PageTest
{
    private const string BaseUrl = "https://www.saucedemo.com/";
    private const string ItemBackpack = "Sauce Labs Backpack";
    private const string ItemBikeLight = "Sauce Labs Bike Light";

    [Test]
    public async Task CompleteCheckout_ShouldSucceed_WhenItemIsRemovedFromCart()
    {
        var loginPage = new LoginPage(Page);
        var productsPage = new ProductsPage(Page);
        var cartPage = new CartPage(Page);
        var checkoutInfoPage = new CheckoutInfoPage(Page);
        var checkoutOverviewPage = new CheckoutOverviewPage(Page);
        var checkoutCompletePage = new CheckoutCompletePage(Page);

        await Page.GotoAsync(BaseUrl);
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await productsPage.AddProductAsync(ItemBackpack);
        await productsPage.AddProductAsync(ItemBikeLight);

        Assert.That(await productsPage.GetCartCountAsync(), Is.EqualTo(2));

        await productsPage.OpenCartAsync();
        await cartPage.RemoveProductAsync(ItemBikeLight);

        Assert.That(await cartPage.GetCartCountAsync(), Is.EqualTo(1));
        Assert.That(await cartPage.IsProductPresentAsync(ItemBackpack), Is.True);

        await cartPage.CheckoutAsync();

        await checkoutInfoPage.FillInformationAsync(
            "Ravindra",
            "Suthar",
            "411001");

        await checkoutInfoPage.ContinueAsync();

        Assert.That(
            await checkoutOverviewPage.IsProductPresentAsync(ItemBackpack),
            Is.True);

        await checkoutOverviewPage.FinishAsync();

        Assert.That(
            await checkoutCompletePage.IsCheckoutCompleteAsync(),
            Is.True);

        Assert.That(
            await checkoutCompletePage.IsConfirmationMessageVisibleAsync(),
            Is.True);
    }
}