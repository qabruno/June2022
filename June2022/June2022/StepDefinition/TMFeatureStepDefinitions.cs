using June2022.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace June2022
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();
            
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new material record")]
        public void WhenICreateANewMaterialRecord()
        {
            tmPageObj.CreateTM(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "June2022", "Actual code and expected code do not match.");
            Assert.That(newDescription == "June2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$12.00", "Actual price and expected price do not match.");
        }

        [When(@"I update '([^']*)', '([^']*)' and '([^']*)' of an existing material record")]
        public void WhenIUpdateAndOfAnExistingMaterialRecord(string p0, string p1, string p2)
        {
            tmPageObj.EditTM(driver, p0, p1, p2);
        }

        [Then(@"the record should have the '([^']*)', '([^']*)' and '([^']*)' updated")]
        public void ThenTheRecordShouldHaveTheAndUpdated(string p0, string p1, string p2)
        {
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.That(editedCode == p0, "Actual code and expected code do not match.");
            Assert.That(editedDescription == p1, "Actual description and expected description do not match.");
            Assert.That(editedPrice == p2, "Actual price and expected price do not match.");
        }


    }
}
