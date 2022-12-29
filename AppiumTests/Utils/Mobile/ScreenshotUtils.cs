using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Drawing;
using System.IO;

namespace AppiumTests.Utils.Mobile
{
    public static class ScreenshotUtils
    {
        [NUnit.Allure.Attributes.AllureStep("Getting element screenshot as a base64 string")]
        public static string GetElementScreenshot(IWebDriver driver,IWebElement element,string path = null)
        {
            try
            {
                var img = Convert.FromBase64String(((AppiumDriver<AndroidElement>)driver).GetScreenshot().AsBase64EncodedString);
                using var ms = new MemoryStream(img, 0, img.Length);
                Image image = Image.FromStream(ms);
                Bitmap bitmap = new Bitmap(image);
                var elementScreenshot = bitmap.Clone(new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height), bitmap.PixelFormat);
                image = elementScreenshot;
                Logger.Info("Element screenshot performed!");
                if (path != null)
                {
                    Logger.Info($"Screenshot saved by path {path}");
                    image.Save(path);
                }
                return Convert.ToBase64String(image.RawFormat.Guid.ToByteArray());
            }
            catch(Exception e)
            {
                Logger.Error("An error occured when tryed to get element screenshot!"+ e.Message);
                return null;
            }
        }
    }
}
