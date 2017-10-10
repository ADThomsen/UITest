using UITest.Runner;
using UITest.Runner.Utils.Extensions;

namespace UITestTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var uiTestRunner = new UITestRunner();
            uiTestRunner.Configuration.Config.Options.Verbose = true;
            uiTestRunner
                .UseBaseUrl("https://google.com")
                .UseChrome()
                .RunFromAssemblyOf<Program>();
        }
    }
}
