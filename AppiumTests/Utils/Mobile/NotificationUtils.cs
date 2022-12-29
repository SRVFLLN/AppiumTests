using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AppiumTests.Utils.Mobile
{
    public static class NotificationUtils
    {
        public static string[] GetNotificationsTitles(AppiumDriver<AndroidElement> driver)
        {
            Logger.Info("Trying to get notification titles...");
            try
            {
                new HttpClient().PostAsync(ConfigManager.Config.RemoteServerAddress + "/session/" + driver.SessionId.ToString() + "/appium/device/open_notifications", null).Wait();
                IList<AndroidElement> notifications = driver.FindElementsById("android:id/title");
                List<string> titles = new List<string>();
                foreach (var notification in notifications)
                    titles.Add(notification.Text);
                driver.ExecuteScript("mobile:shell", new Dictionary<string, string>(){ {"command", "input keyevent"},{"args","4"} });
                return titles.ToArray();
            }
            catch(Exception e)
            {
                Logger.Error($"Error occured when trying to get notification titles: {e.Message}");
                return null;
            }
        }
    }
}
