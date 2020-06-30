using MarsFramework.Pages;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using OpenQA.Selenium;

using NUnit.Framework;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class ProfileDescriptionSteps
    {
        [Given(@"I add or update the Description on profile page")]
        public void GivenIAddOrUpdateTheDescriptionOnProfilePage()
        {
            //   ScenarioContext.Current.Pending();
            //Read data from excel data file
            ExcelLib.PopulateInCollection(ExcelPath, "profile");
            string profileDescription = ExcelLib.ReadData(2, "Description");
            // Add/edit/update description
            profile profileObj = new profile();
            profileObj.EditProfileDesc(profileDescription);
        }

        [Then(@"I should be able to add or update the Description")]
        public void ThenIShouldBeAbleToAddOrUpdateTheDescription()
        {
            // ScenarioContext.Current.Pending();
            //Validate the message confirmation displayed
            string expMessage = "Description has been saved successfully";
            string actMessage = driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expMessage, actMessage, "Getting expected message failed");
            
            string profileDescription = ExcelLib.ReadData(2, "Description");
            //Validate - Description display correctly
            string actDescription = driver.FindElement(By.XPath("//span[contains(@style,'padding-top: 1em;')]")).Text;
            Assert.AreEqual(profileDescription, actDescription, "Description mismatch - update has failed");
        }
    }
}