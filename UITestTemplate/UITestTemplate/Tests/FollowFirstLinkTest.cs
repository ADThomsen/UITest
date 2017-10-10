using OpenQA.Selenium;
using UITest.Core;
using UITest.Core.Attributes;

namespace UITestTemplate.Tests
{
    [UseCase(DependsOn = new[] { typeof(MakeSearchTest) })]
    public class FollowFirstLinkTest : UseCase
    {
        public override void Test()
        {
            Load()
                .Type(By.Id("lst-ib"), "vertica a/s", 500)
                .Type(By.Id("lst-ib"), Keys.Enter, 500)
                .Click(By.CssSelector("._NId a"), 500)
                .Assert
                .ContainsText(By.TagName("h1"), "Vi elsker e-handel!");
        }
    }
}