using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blazor.JSInterop.Helpers.E2ETests
{
    /// <summary>
    /// Contains extensions for the IWebDriver
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds an element given the selector and the timeout
        /// </summary>
        /// <param name="driver">The web driver to be used</param>
        /// <param name="by">The selector to be used</param>
        /// <param name="timeout">The timeout period to be used</param>
        /// <returns>A web element if found; null otherwise</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            return new WebDriverWait(driver, timeout)
                    .Until(driver => driver.FindElement(by));
        }
    }
}
