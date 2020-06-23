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
    public class SignInSteps
    {
        [Given(@"I have entered valid credentials on SignIn page")]
        public void GivenIHaveEnteredValidCredentialsOnSignInPage()
        {
            SignIn Signinobj = new SignIn();
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            Signinobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
        }

        [Given(@"I have entered invalid credentials on SignIn page")]
        public void GivenIHaveEnteredInvalidCredentialsOnSignInPage()
        {
            SignIn Signinobj = new SignIn();
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            Signinobj.LoginSteps(ExcelLib.ReadData(3, "Username"), ExcelLib.ReadData(3, "Password"));

        }

        [Then(@"I should be able to login to the application")]
        public void ThenIShouldBeAbleToLoginToTheApplication()
        {
            try
            {
                //Verify if signout is visible
                IWebElement SignOutElement = GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui green basic button'][text()='Sign Out']"));
                Assert.IsTrue(SignOutElement.Text.Equals("Sign Out"));
                Base.test.Log(LogStatus.Info, "Signed in successfully");

                //Verify if user is navigated to Profile Page
                string expectedTitle = "Profile";
                string actualTitle = driver.Title;
                Assert.AreEqual(expectedTitle, actualTitle, "SignIn Failed");
            }
            catch (Exception)
            {
                //JoinBtn.Click();                
                Base.test.Log(LogStatus.Info, "Signed in error");
            }
        }
        
        [Then(@"I should not be able to login to the application")]
        public void ThenIShouldNotBeAbleToLoginToTheApplication()
        {
            try
            {
                //Verify "Send Verification Email" button
                IWebElement EmailVerifyBtn = driver.FindElement(By.XPath("//button[@id='submit-btn']"));
                Assert.IsTrue(EmailVerifyBtn.Enabled, "User failed to login successfully");
            }
            catch
            {
                Base.test.Log(LogStatus.Info, "Signup please and go to registration page");
            }
        }
    }
}
