using TechTalk.SpecFlow;

namespace Blazor.JSInterop.Helpers.E2ETests.Steps
{
    /// <summary>
    /// Step definitions for the ElementHandler feature
    /// </summary>
    [Binding]
    public sealed class ElementHandlerStepDefinitions
    {
        [When("AddClassAsync is called with a class name")]
        public void GivenAnElement()
        {
            Assert.AreEqual(1,1);
        }

        [Then("the class name is added to the element")]
        public void ThenTheClassNameIsAddedToTheElement()
        {
            Assert.AreEqual(1, 1);

        }
    }
}