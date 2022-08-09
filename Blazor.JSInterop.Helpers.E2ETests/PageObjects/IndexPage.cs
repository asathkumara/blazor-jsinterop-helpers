using OpenQA.Selenium;

namespace Blazor.JSInterop.Helpers.E2ETests.PageObjects
{
    /// <summary>
    /// Page object model for the Index Page
    /// </summary>
    public class IndexPage
    {
        private const string IndexUrl = @"https://localhost:7149/";
        private readonly IWebDriver _driver;

        private IWindow _window => _driver.Manage().Window;
        private IWebElement _headingOneElement => _driver.FindElement(By.Id("headingOne"));
        private IWebElement _focusHeadingButtonElement => _driver.FindElement(By.Id("focusHeadingButton"));

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
            _focusHeadingButtonElement.Click();
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
