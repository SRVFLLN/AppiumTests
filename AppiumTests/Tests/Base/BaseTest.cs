using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTests.Tests.Base
{
    [AllureNUnit]
    public class BaseTest
    {
        public AppiumDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            Utils.Logger.LoadConfiguration();
            Utils.AllureReportsUtils.ClearFolder();
            Utils.Mobile.ConfigManager.InitializeConfig();
        }

        [OneTimeTearDown] 
        public void AfterAll()
        {
            Utils.Mobile.AndroidDriver.appiumLocalService?.Dispose();
            Utils.AllureReportsUtils.RunAllureReports();
        }
    }
}