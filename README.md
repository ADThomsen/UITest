# UI Test
UI Test is a framework that makes it simple and intuitive to write robust and reliable regression tests for you UI in C#.

## Getting started
Create a new console application and add the following three NuGet packages available on nuget.org
- [UITest.Core](https://www.nuget.org/packages/UITest.Core/)
- [UITest.Runner](https://www.nuget.org/packages/UITest.Runner/)
- [UITest.ChromeDriver](https://www.nuget.org/packages/UITest.ChromeDriver/)

Alternatively take a clone of this repository and use the UITestTemplate as a starting point.

## Configuring the runner
In your programs `Main` method you need to start the runner in order to run your tests.

```csharp
new UITestRunner()
  .RunFromAssemblyOf<Program>();
```

To let the runner know how to run your tests there are a number of extension methods that can be used.

### `.UseBaseURL()`
Sets the base URL for all tests. Setting this means you won't have to set the URL for each test

### `.UseChrome(bool headless = false)`
Tells the runner to run the tests in Chrome (currently only Chrome and Browserstack are supported). Optionally add `true` to the method to utilize Chrome's headless mode. This requires Chrome 61 or higher.

### `.UsePortableChromium(string revision = null)`
Downloads a revision of the portable Chromium browser. If no revision is supplied the method defaults to the latest version that is gauranteed to work with UITest. Use the default unless you have a spedific need for a different version.

### `.UseUseCases(Type[] useCaseTypes)`
Specify which use case(s) to run for a single test run. This is useful when writing new tests to only run that test.

### `.UseWindowSizes(string[] windowSizes)`
Use this method to specify for which window sizes you want to run your tests. If a test has it's own window sizes, only the intersection between those window sizes and those specified in `UseWindowSizes()` will be used for that particular test.

### `.RunInParallel()`
Runs all tests in parallel (maximum of 5 at a time). Use this to speed up local test runs. Works best with headless Chrome. Be aware that dependencies between tests are currently not supported when running in parallel.

### `.Delay(int milliseconds)`
Using this method will delay all interactions and assertions by the number of milliseconds specified. Use this to slow down your test while debugging

## Writing your first test
To write a test simple create a class that inherits from `UseCase` and give the `UseCaseAttribute` attribute. The only method that has to be implemented is `Test`.
Your are free to do whatever you wan't inside the `Test` method but it is recommended that you start with the `Load` method and work from there.

```csharp
using OpenQA.Selenium;
using UITest.Core;
using UITest.Core.Attributes;

namespace UITestTemplate.Tests
{
    [UseCase]
    public class LoadPageTest : UseCase
    {
        // Check that the page loads and that logo, input field and search button exists
        public override void Test()
        {
            Load()
                .Assert
                .IsVisible(By.Id("hplogo"), 500)
                .IsVisible(By.Id("lst-ib"), 500)
                .Exists(UITestBy.AttributeValue("aria-label", "Google-søgning"), 500); // replace with whatever the search button says in your language
        }
    }
}
```
