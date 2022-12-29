using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects;
using SeleniumExtras.PageObjects;

namespace AppiumTests.PageObjects.Mobile.Base
{
    public abstract class BaseScreen
    {
        protected IWebDriver driver;
        private static readonly TimeOutDuration _duration = new TimeOutDuration(System.TimeSpan.FromSeconds(5));
        private static readonly AppiumPageObjectMemberDecorator _decorator = new AppiumPageObjectMemberDecorator(_duration);
        private string _pageName;
        private string _pageType;

        public string PageName
        {
            get => _pageName;
            protected set => _pageName = value;
        }

        public string PageType
        {
            get => _pageType;
            protected set => _pageType = value;
        }

        public BaseScreen(string pageName, string pageType, IWebDriver driver)
        {
            this.driver = driver;
            PageName = pageName;
            PageType = pageType;
            PageFactory.InitElements(driver, this, _decorator);
        }

        public BaseScreen(string pageName, string pageType, By rootLocator, IWebDriver driver)
        {
            this.driver = driver;
            PageName = pageName;
            PageType = pageType;
            PageFactory.InitElements(driver.FindElement(rootLocator), this, _decorator);
        }
    }
}
