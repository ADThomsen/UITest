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
                .Exists(UITestBy.AttributeValue("aria-label", "Google-søgning"), 500);
        }
    }
}