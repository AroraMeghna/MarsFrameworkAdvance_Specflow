using MarsFramework.Global;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using MarsFramework.Pages;
using NUnit.Framework;
using static MarsFramework.Global.Base;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class RegisrationSteps
    {
        [Given(@"I have navigated to registration page and entered all valid credentials and click join")]
        public void GivenIHaveNavigatedToRegistrationPageAndEnteredAllValidCredentialsandclickjoin()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            string regFirstname = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");
            string regLastname = GlobalDefinitions.ExcelLib.ReadData(2, "LastName");
            string regEmail = GlobalDefinitions.ExcelLib.ReadData(2, "Email");
            string regPasswd = GlobalDefinitions.ExcelLib.ReadData(2, "Password");
            string regConfirmPswd = GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd");

            SignUp Signupobj = new SignUp();
            Signupobj.register(ExcelLib.ReadData(2, "FirstName"), ExcelLib.ReadData(2, "LastName"), ExcelLib.ReadData(2, "Email"), ExcelLib.ReadData(2, "Password"), ExcelLib.ReadData(2, "ConfirmPswd"));
        }

        [Then(@"the message confirmation is displayed on screen")]
        public void ThenTheMessageConfirmationIsDisplayedOnScreen()
        {
            try
            {
                String actualErrorEmail = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='field error ']")).Text;
                String expectedErrorEmail = "This email has already been used to register an account.";
                //Type 1
                Assert.AreEqual(actualErrorEmail, expectedErrorEmail);
                //Type 2
                Assert.True(actualErrorEmail.Contains("This email has already been used to register an account."));
                Base.test.Log(LogStatus.Info, "Signup completed");
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Signup had issues");
                GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
            }

        }
    }
}
