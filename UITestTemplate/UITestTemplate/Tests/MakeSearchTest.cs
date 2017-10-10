using OpenQA.Selenium;
using UITest.Core;
using UITest.Core.Attributes;

namespace UITestTemplate.Tests
{
    [UseCase(DependsOn = new[] { typeof(LoadPageTest) })]
    public class MakeSearchTest : UseCase
    {
        // Tests that a search can be performed and that the first search result is Vertica A/S
        public override void Test()
        {
            Load()
                .Type(By.Id("lst-ib"), "vertica a/s", 500)
                .Type(By.Id("lst-ib"), Keys.Enter, 500)
                .Assert
                .HasAttributeValue(By.CssSelector("._NId link"), "href", "https://www.vertica.dk/");
        }
    }
}