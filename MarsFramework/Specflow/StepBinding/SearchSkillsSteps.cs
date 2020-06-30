using MarsFramework.Pages;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using System.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    public class SearchSkillsSteps
    {
        private ScenarioContext _scenarioContext;
        public SearchSkillsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I click search icon on Profile Page")]
        public void GivenIClickSearchIconOnProfilePage()
        {
            //Search by category and subcategory
            var searchSkillsObj = new Searchskills();
            _scenarioContext["searchSkillsObj"] = searchSkillsObj;
            searchSkillsObj.ClickSearch();
        }

        [Given(@"I input search skills")]
        public void GivenIInputSearchSkills()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "Search-Skills");
            string searchSkill = ExcelLib.ReadData(2, "SearchSkills");

            var searchSkillsObj = (Searchskills)_scenarioContext["searchSkillsObj"];
            _scenarioContext["searchSkill"] = searchSkill;
            searchSkillsObj.skillSearchInput(searchSkill);
        }

        [When(@"I click category and subcategory")]
        public void WhenIClickCategoryAndSubcategory()
        {

            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "Search-Skills");
            //string searchSkill = ExcelLib.ReadData(2, "SearchSkills");
            //var searchSkillsObj = (Searchskills)_scenarioContext["searchSkillsObj"];
            //_scenarioContext["searchSkill"] = searchSkill;
            //searchSkillsObj.skillSearchInput(searchSkill);

            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(4, "SubCategory");

           // _scenarioContext["category"] = category;
            //_scenarioContext["subcategory"] = subcategory;
            //var SearchskillsObj = (Searchskills)_scenarioContext["SearchskillsObj"];
            //SearchskillsObj.SkillsCategory(category, subcategory);
            
            var SearchskillsObj = new Searchskills();
            SearchskillsObj.ClickSearch();
            SearchSkillsOnline();
            SearchskillsObj.SkillsCategory(category, subcategory);

        }

        [When(@"I choose Filter by Online")]
        public void WhenIChooseFilterByOnline()
        {
            //ExcelLib.PopulateInCollection(Base.ExcelPath, "Search-Skills");
            //string profileDescription = ExcelLib.ReadData(2, "SearchSkills");
            // Add/edit/update description
            //Searchskills SearchskillsObj = new Searchskills();
            //SearchskillsObj.skillSearchInput(profileDescription);

        }


                
        [Then(@"The search results should be displayed by category and subcategory")]
        public void ThenTheSearchResultsShouldBeDisplayedByCategoryAndSubcategory()
        {
            //Search by category and subcategory
            //var SearchskillsObj = new Searchskills();
            //SearchskillsObj.ClickSearch();
            //SearchSkillsOnline();
            //SearchskillsObj.SkillsCategory(category, subcategory);
        }

        private void SearchSkillsOnline()
        {
            //throw new NotImplementedException();
        }

        [Then(@"The search results should be filtered by Online")]
        public void ThenTheSearchResultsShouldBeFilteredByOnline()
        {
            try
            {
                //String ActualTitle = GlobalDefinitions.driver.Title;
                //String ExpectedTitle = "Search";
                //NUnit.Core.NUnitFramework.Assert.AreEqual(ExpectedTitle, ActualTitle);
                //Base.test.Log(LogStatus.Info, "Search skills validated successfully");

                //IWebElement searchOutcome = GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'Refine Results')]"));
                //object O = NUnit.Core.NUnitFramework.Assert.IsTrue(searchOutcome.Text.Equals("Refine Results"));
                //Base.test.Log(LogStatus.Info, "Search skills returned successfully with results");
            }
            catch (AssertionException)
            {
                //JoinBtn.Click();
                //Base.test.Log(LogStatus.Info, "Search skills exception handeled successfully");
            }

        }

       
    }
}
