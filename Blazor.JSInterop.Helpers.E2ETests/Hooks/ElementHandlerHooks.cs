using Blazor.JSInterop.Helpers.E2ETests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Blazor.JSInterop.Helpers.E2ETests.Hooks
{
    [Binding]
    public sealed class ElementHandlerHooks
    {
        private IWebDriver _driver;

        /// <summary>
        /// Initialize WebDriver and Index page
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            IndexPage indexPage = new IndexPage(_driver);
            indexPage.Open();
        }

        /// <summary>
        /// Close WebDriver
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}