using Blazor.JSInterop.Helpers.E2ETests.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Blazor.JSInterop.Helpers.E2ETests.Steps
{
    /// <summary>
    /// Step definitions for the ElementHandler feature
    /// </summary>
    [Binding]
    public sealed class ElementHandlerStepDefinitions
    {
        private readonly IndexPage _indexPage;

        public ElementHandlerStepDefinitions(IWebDriver driver)
        {
            _indexPage = new IndexPage(driver);
            _indexPage.Open();
        }

        [When("FocusAsync is called on an element")]
        public void WhenFocusAsyncIsCalled()
        {
            _indexPage.ClickFocusHeadingOneButton();
        }

        [Then("the element is focused")]
        public void ThenTheElementIsFocused()
        {
            Assert.That(_indexPage.FocusedElement, Is.EqualTo(_indexPage.HeadingOneElement));

        }

        //[When("AddClassAsync is called with a class name")]
        //public void WhenAddClassAsyncIsCalled()
        //{
        //    Assert.AreEqual(1, 1);
        //}

        //[Then("the class name is added to the element")]
        //public void ThenTheClassNameIsAdded()
        //{
        //    Assert.AreEqual(1, 1);

        //}
    }
}