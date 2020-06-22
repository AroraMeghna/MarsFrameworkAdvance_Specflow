using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow.StepBinding
{
    [Binding]
    class Hooks : Base
    {
        #region setup and tear down
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            switch (Browser)
            {
                case 1:
                    driver = new FirefoxDriver();
                    break;
                case 2:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(Url);
                    break;
            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);
            test = extent.StartTest(scenarioContext.ScenarioInfo.Title);
            #endregion

            if (featureContext.FeatureInfo.Title != "SignIn")
            {
                if (IsLogin == "true")
                {
                    SignIn loginobj = new SignIn();
                    //Populate the excel data
                    ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
                    loginobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
                }
                else
                {
                    SignUp Signupobj = new SignUp();
                    Signupobj.register(ExcelLib.ReadData(2, "FirstName"), ExcelLib.ReadData(2, "LastName"), ExcelLib.ReadData(2, "Email"), ExcelLib.ReadData(2, "Password"), ExcelLib.ReadData(2, "ConfirmPswd"));
                }
            }
            //Set Implicit Wait
            GlobalDefinitions.wait(20);
        }


        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            //Get test restult
            var status = scenarioContext.TestError;

            // Screenshot
            string screenShotPath = SaveScreenShotClass.SaveScreenshot(driver, TestContext.CurrentContext.Test.Name);

            // Write log to report
            LogStatus logstatus;
            if (status != null)
            {
                logstatus = LogStatus.Fail;
                test.Log(logstatus, "Test ended with " + logstatus + "–" + scenarioContext.TestError.Message);
                test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
            }
            else
            {
                logstatus = LogStatus.Pass;
                test.Log(logstatus, "Test ended with " + logstatus);
                test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
            }
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver      
            driver.Close();
            driver.Quit();
        }
        #endregion
    }
}
