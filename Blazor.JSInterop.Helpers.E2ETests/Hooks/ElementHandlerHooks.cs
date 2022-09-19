using Blazor.JSInterop.Helpers.E2ETests.PageObjects;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Blazor.JSInterop.Helpers.E2ETests.Hooks
{
    /// <summary>
    /// Contains automation logic for the ElementHandler feature
    /// </summary>
    [Binding]
    public sealed class ElementHandlerHooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;


        public ElementHandlerHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Initialize and register WebDriver before every scenario
        /// </summary>
        /// <remarks>The driver is registered to the ObjectContainer as a dependency for the binding classes</remarks>
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs(_driver);
        }

        /// <summary>
        /// Close WebDriver after every scenario
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}