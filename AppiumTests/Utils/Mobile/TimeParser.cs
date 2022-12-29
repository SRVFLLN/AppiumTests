using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;   

namespace AppiumTests.Utils.Mobile
{
    //2022-12-27T13:13:32+00:00 <- Example
    public static class TimeParser
    {
        private static string[] times;
        private static DateTime date;
        private static DateTime time;

        private static void ParseTime(AppiumDriver<IWebElement> driver)
        {
            times = driver.DeviceTime.Split('T');
            date = DateTime.Parse(times[0]);
            time = DateTime.Parse(times[1]);
        }

        public static DateTime GetTime(AppiumDriver<IWebElement> driver)
        {
            ParseTime(driver);
            return time;
        }

        public static DateTime GetDate(AppiumDriver<IWebElement> driver)
        {
            ParseTime(driver);
            return date;
        }
    }
}
