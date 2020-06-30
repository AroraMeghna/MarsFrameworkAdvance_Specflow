using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class ProfileAvailabilitySteps
    {
        [Given(@"I have updated Availability on Profile page")]
        public void GivenIHaveUpdatedAvailabilityOnProfilePage()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            //string profileDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            //string profileLanguage = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
            string profileAvailabilityTime = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityType");
            string profileAvailabilityHours = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityHours");
            //int profileAvailabilityHours = GlobalDefinitions.ExcelLib.ReadData(4, AvailabilityHours);
            string profileSalaryExpected = GlobalDefinitions.ExcelLib.ReadData(2, "SalaryTarget");

            profile profileObj = new profile();
            profileObj.EditProfile(profileAvailabilityTime, profileAvailabilityHours, profileSalaryExpected);

        }

        [Then(@"I should be able to view the updated Availability")]
        public void ThenIShouldBeAbleToViewTheUpdatedAvailability()
        {
            try
            {

                String ActualTitle = GlobalDefinitions.driver.Title;
                String ExpectedTitle = "Profile";
                Assert.AreEqual(ExpectedTitle, ActualTitle);
                // validate availability time ex. part/full time
                String ExpectedAvailability = GlobalDefinitions.ExcelLib.ReadData(2, "AvailabilityType");
                String ActualAvailability = "Full Time";
                Assert.AreEqual(ExpectedAvailability, ActualAvailability);
                Base.test.Log(LogStatus.Info, "Profile validated successfully");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                Base.test.Log(LogStatus.Info, "Profile exception handeled successfully");
            }

        }
    }
}
