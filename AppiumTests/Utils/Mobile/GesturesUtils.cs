using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;

namespace AppiumTests.Utils.Mobile
{
    public static class GesturesUtils
    {
        private const int DEFAULT_WAIT_TIME_MS = 300;

        public static void SwipeElementToCoord(IWebElement element, int xCoord, int yCoord, AppiumDriver<IWebElement> driver, int waitTime = DEFAULT_WAIT_TIME_MS)
        {
            new TouchAction(driver)
                .Press(element.Location.X, element.Location.Y)
                .Wait(waitTime)
                .MoveTo(xCoord, yCoord)
                .Release()
                .Perform();
        }

        public static void SwipeElementToOtherElement(IWebElement interactionElement, IWebElement targetElement, AppiumDriver<IWebElement> driver, int waitTime = DEFAULT_WAIT_TIME_MS)
        {
            new TouchAction(driver)
            .Press(interactionElement,interactionElement.Location.X, interactionElement.Location.Y)
            .Wait(waitTime)
            .MoveTo(targetElement, targetElement.Location.X, targetElement.Location.Y)
            .Release()
            .Perform();
        }

        public static void SwipeElement(IWebElement element, SwipeDirections direction, AppiumDriver<AndroidElement> driver, int waitTime = DEFAULT_WAIT_TIME_MS)
        {
            var performer = (IPerformsTouchActions)driver;
            var Width = driver.Manage().Window.Size.Width;
            var Height = driver.Manage().Window.Size.Height;
            int xCoord = element.Location.X, yCoord = element.Location.Y;
            switch (direction)
            {
                case SwipeDirections.Left:
                    xCoord = 1;
                    break;
                case SwipeDirections.Right:
                    xCoord = Width - 1;
                    break;
                case SwipeDirections.Up:
                    yCoord = Height - 1;
                    break;
                case SwipeDirections.Down:
                    yCoord = 1;
                    break;
            }
            new TouchAction(performer)
                .Press(element)
                .Wait(waitTime)
                .MoveTo(xCoord, yCoord)
                .Release()
                .Perform();
            Logger.Info($"Swiped from {direction}. Coord: {xCoord};{yCoord}");
        }

        public enum SwipeDirections
        {
            Left,
            Right,
            Up,
            Down
        }
    }
}
