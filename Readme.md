# SauceDemo Playwright Automation

## Overview

This project automates the SauceDemo checkout flow using C#, Playwright, NUnit, and the Page Object Model (POM).

The automation covers the complete checkout journey, including adding products to the cart, removing an item, validating the remaining product, entering checkout information, and verifying successful order completion.

## Tech Stack

- C#
- .NET 10
- Playwright
- NUnit
- Page Object Model (POM)
- Visual Studio Code

## Automated Flow

1. Open SauceDemo.
2. Log in using valid credentials.
3. Add **Sauce Labs Backpack** to the cart.
4. Add **Sauce Labs Bike Light** to the cart.
5. Verify that the cart count is `2`.
6. Open the cart.
7. Remove **Sauce Labs Bike Light**.
8. Verify that the cart count is `1`.
9. Verify that **Sauce Labs Backpack** is still present.
10. Proceed to checkout.
11. Enter first name, last name, and postal code.
12. Continue to the checkout overview.
13. Verify that the remaining product is displayed correctly.
14. Finish the checkout.
15. Verify **Checkout: Complete!**.
16. Verify the order confirmation message.

## Project Structure

```text
SauceDemoPlaywrightAutomation/
├── Pages/
│   ├── LoginPage.cs
│   ├── ProductsPage.cs
│   ├── CartPage.cs
│   ├── CheckoutInfoPage.cs
│   ├── CheckoutOverviewPage.cs
│   └── CheckoutCompletePage.cs
├── Tests/
│   └── CheckoutTest.cs
├── .gitignore
├── README.md
└── SauceDemoPlaywrightAutomation.csproj
```

## Page Object Model

The project uses Page Object Model to keep page-specific locators and actions separate from the test.

### LoginPage

Handles:

- Username
- Password
- Login action

### ProductsPage

Handles:

- Adding products
- Reading the cart count
- Opening the cart

Products are added through the reusable method:

```csharp
AddProductAsync(string productName)
```

This allows the same method to be used for different products instead of creating a separate method for each product.

### CartPage

Handles:

- Reading the cart count
- Removing products
- Checking whether a product is present
- Starting checkout

Products are removed through:

```csharp
RemoveProductAsync(string productName)
```

### CheckoutInfoPage

Handles:

- First name
- Last name
- Postal code
- Continue action

### CheckoutOverviewPage

Handles:

- Verifying the remaining product
- Finishing the checkout
- Waiting for the checkout completion page

### CheckoutCompletePage

Handles verification of:

- `Checkout: Complete!`
- Order confirmation message

## Locators

The automation primarily uses SauceDemo's `data-test` attributes for the main UI elements.

Examples:

```text
[data-test='username']
[data-test='password']
[data-test='login-button']
[data-test='shopping-cart-link']
[data-test='shopping-cart-badge']
[data-test='inventory-item-name']
[data-test='checkout']
[data-test='continue']
[data-test='finish']
[data-test='title']
[data-test='complete-text']
```

## Running the Tests

### Build the project

```bash
dotnet build
```

### Run the test

```bash
dotnet test
```

The test runs using Playwright's default headless browser mode.

### Run with a visible browser

For debugging or demonstration, use:

```bash
PWDEBUG=1 dotnet test
```

This opens the browser and allows the automation flow to be observed while the test is running.

## Playwright Browser Setup

If the required Playwright browsers have not been installed, run:

```bash
pwsh bin/Debug/net10.0/playwright.ps1 install
```

After installation, the tests can be executed using:

```bash
dotnet test
```

## Test Result

The checkout automation has been executed successfully.

```text
Test summary: total: 1, failed: 0, succeeded: 1, skipped: 0
```

## Notes

- `bin/` and `obj/` are excluded from Git using `.gitignore`.
- The test uses Playwright's `PageTest` base class for browser and page management.
- Reusable page methods are used for product actions.
- The automation focuses on the required checkout scenario.
- The optional receipt/PDF download is not included in the automated flow.

## Application Under Test

SauceDemo:

https://www.saucedemo.com/
