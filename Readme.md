# SauceDemo Playwright Automation

## Overview

This project is a UI test automation framework created for the SauceDemo checkout assessment.

The automation uses **C#**, **Playwright**, **NUnit**, and the **Page Object Model (POM)** design pattern to automate and validate a complete shopping checkout workflow.

## Technologies Used

- C#
- .NET 10
- Microsoft Playwright
- NUnit
- Page Object Model (POM)
- Visual Studio Code

## Assessment Flow

The automated test performs the following steps:

1. Open the SauceDemo website.
2. Log in using valid credentials.
3. Add **Sauce Labs Backpack** to the cart.
4. Add **Sauce Labs Bike Light** to the cart.
5. Verify that the cart contains 2 items.
6. Open the cart.
7. Remove the **Sauce Labs Bike Light**.
8. Verify that the cart contains 1 item.
9. Verify that **Sauce Labs Backpack** remains in the cart.
10. Click **Checkout**.
11. Enter first name, last name, and postal code.
12. Continue to the Checkout Overview page.
13. Verify that **Sauce Labs Backpack** is displayed on the Overview page.
14. Click **Finish**.
15. Verify the **Checkout: Complete!** page.
16. Verify the order confirmation message.

## Project Structure

```text
SauceDemoPlaywrightAutomation/
│
├── Pages/
│   ├── LoginPage.cs
│   ├── ProductsPage.cs
│   ├── CartPage.cs
│   ├── CheckoutInfoPage.cs
│   ├── CheckoutOverviewPage.cs
│   └── CheckoutCompletePage.cs
│
├── Tests/
│   └── CheckoutTest.cs
│
├── .gitignore
├── README.md
└── SauceDemoPlaywrightAutomation.csproj
```

## Page Object Model

The project separates page-specific locators and actions into individual classes.

- **LoginPage** – Handles username, password, and login.
- **ProductsPage** – Handles adding products and checking the cart count.
- **CartPage** – Handles cart verification, product removal, and checkout.
- **CheckoutInfoPage** – Handles customer information and continuing to checkout.
- **CheckoutOverviewPage** – Verifies the remaining product and completes checkout.
- **CheckoutCompletePage** – Verifies the final checkout completion and confirmation message.

## Running the Test

### Prerequisites

Make sure the following are installed:

- .NET SDK
- Google Chrome
- Playwright browsers

### Build the project

```bash
dotnet build
```

### Run the automated test

```bash
dotnet test
```

The test launches Chrome and executes the complete checkout workflow.

## Test Result

The completed automation was successfully executed with:

```text
Test summary: total: 1, failed: 0, succeeded: 1, skipped: 0
```

## Notes

- The project uses `data-test` attributes for clear and stable element identification.
- Playwright's waiting mechanisms are used where necessary to wait for elements to become visible.
- Generated build folders such as `bin/` and `obj/` are excluded from version control through `.gitignore`.
