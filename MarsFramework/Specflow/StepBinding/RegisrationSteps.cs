using MarsFramework.Global;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using MarsFramework.Pages;
using NUnit.Framework;
using static MarsFramework.Global.Base;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class RegisrationSteps
    {

        [Given(@"I have navigated to registration page and entered all valid credentials")]
        public void GivenIHaveNavigatedToRegistrationPageAndEnteredAllValidCredentials()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            string regFirstname = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");
            string regLastname = GlobalDefinitions.ExcelLib.ReadData(2, "LastName");
            string regEmail = GlobalDefinitions.ExcelLib.ReadData(2, "Email");
            string regPasswd = GlobalDefinitions.ExcelLib.ReadData(2, "Password");
            string regConfirmPswd = GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd");

            SignUp Signupobj = new SignUp();
            Signupobj.register(regFirstname, regLastname, regEmail, regPasswd, regConfirmPswd);

        }

        [When(@"I click on Join button")]
        public void WhenIClickOnJoinButton()
        {
           
        }
        
        [Then(@"the message confirmation is displayed on screen")]
        public void ThenTheMessageIsDisplayedOnScreen()
        {
           
        }
    }
}
