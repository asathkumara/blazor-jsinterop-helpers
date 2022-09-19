using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blazor.JSInterop.Helpers.E2ETests.PageObjects
{
    /// <summary>
    /// Page object model for the Index Page
    /// </summary>
    public class IndexPage
    {
        private const string IndexUrl = @"https://localhost:7149/";
        private const int DefaultTimeout = 10;
        private readonly IWebDriver _driver;

        private IWindow _window => _driver.Manage().Window;
        public IWebElement HeadingOneElement => _driver.FindElement(By.Id("headingOne"), TimeSpan.FromSeconds(DefaultTimeout));
        public IWebElement FocusHeadingOneButtonElement => _driver.FindElement(By.Id("focusHeadingButton"), TimeSpan.FromSeconds(DefaultTimeout));

        public IWebElement FocusedElement => _driver.SwitchTo().ActiveElement();

        /// <summary>
        /// Constructs the Index page object with the given driver
        /// </summary>
        /// <param name="driver">The web driver to be used for testing</param>
        public IndexPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Opens the Index page
        /// </summary>
        public void Open()
        {
            _driver.Navigate().GoToUrl(IndexUrl);
        }

        public void ClickFocusHeadingOneButton()
        {
            FocusHeadingOneButtonElement.Click();
        }

        public void Minimize()
        {
            _window.Minimize();
        }

        public void Maximize()
        {
            _window.Maximize();
        }

    }
}
