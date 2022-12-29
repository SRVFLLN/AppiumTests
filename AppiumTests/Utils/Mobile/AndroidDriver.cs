using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace AppiumTests.Utils.Mobile
{
    public static class AndroidDriver
    {
        private const int DEFAULT_IMPLICIT_WAIT = 120;
        private static AppiumDriver<AndroidElement> driver;
        public static AppiumLocalService appiumLocalService;
        private static AppiumOptions appiumOptions;

        private static void InitializeOptions()
        {
            appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, ConfigManager.Config.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, ConfigManager.Config.PlatformName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, ConfigManager.Config.PlatformVersion);
        }

        private static void StartDriver()
        {
            driver = new AndroidDriver<AndroidElement>(new Uri(ConfigManager.Config.RemoteServerAddress), appiumOptions);
            ((IContextAware)driver).Context = ((IContextAware)driver).Contexts.FirstOrDefault(c => c.Contains("WEBVIEW"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_IMPLICIT_WAIT);
            Logger.BrowserName = $"{ConfigManager.Config.DeviceName} {ConfigManager.Config.PlatformName}:{ConfigManager.Config.PlatformVersion}";
            Logger.SessionId = driver.SessionId.ToString();
        }

        [NUnit.Allure.Attributes.AllureStep("Create driver and open browser")]
        public static AndroidDriver<AndroidElement> CreateDriverWBrowser()
        {
            InitializeOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, ConfigManager.Config.BrowserName);
            var opt = new Dictionary<string, bool>
            {
                { "w3c", false }
            };
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.ChromeOptions, opt);
            appiumOptions.AddAdditionalCapability("chromedriverExecutable", Directory.GetCurrentDirectory() + "/Resources/chromedriver.exe");
            StartDriver();
            Logger.BrowserName += $" {ConfigManager.Config.BrowserName}";
            driver.Context = "CHROMIUM";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(DEFAULT_IMPLICIT_WAIT);
            return (AndroidDriver<AndroidElement>)driver;
        }

        [NUnit.Allure.Attributes.AllureStep("Create driver and open app")]
        public static AndroidDriver<AndroidElement> CreateDriverWApp()
        {
            InitializeOptions();
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, ConfigManager.Config.AppPackage);
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, ConfigManager.Config.AppActivity);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Directory.GetCurrentDirectory() + "/Resources/app-debug.apk");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, ConfigManager.Config.AppActivity);
            StartDriver();
            Logger.BrowserName += $" {ConfigManager.Config.AppPackage} {ConfigManager.Config.AppActivity}";
            return (AndroidDriver<AndroidElement>)driver;
        }
    }
}
