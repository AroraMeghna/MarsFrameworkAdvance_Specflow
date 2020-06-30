/*using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;
using NUnit.Framework;*/
using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class ProfileLanguageSteps
    {
        [Given(@"I Edit or update Language on profile page")]
        public void GivenIEditOrUpdateLanguageOnProfilePage()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "profile");
            string profileLangName = ExcelLib.ReadData(2, "Language");
            string profileLangLevel = ExcelLib.ReadData(2, "LangLevel");
            // edit/update language name and level
            profile profileObj = new profile();
            profileObj.EditProfileLang(profileLangName, profileLangLevel);

          
        }
        
        [Then(@"I should be able to view the updated Language")]
        public void ThenIShouldBeAbleToViewTheUpdatedLanguage()
        {
            string profileLangName = ExcelLib.ReadData(2, "Language");
            string actualMsg = driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            //string expectedMsg = profileLangName + " " + "has been added to your languages";
            Assert.IsTrue(actualMsg.Contains(" your languages"));
           
        }
    }
}
