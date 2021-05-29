using System;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace BaseProject.Extensions
{
   
    public static class WebDriverExtensions
    {

        public static void NavigateToHomePage(this IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(TestConfig.HomePage);
            webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
        }

        public static IWebElement FindElement(this IWebDriver driver, int waitTime, By waitingElement)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime))
                .Until(ExpectedConditions.ElementExists(waitingElement));
        }

        public static IWebElement FindElement(this IWebElement element, int waitTime, By waitingElement)
        {
            Thread.Sleep(waitTime);
            return element.FindElement(waitingElement);
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            var _element = element;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", _element);
        }

        public static void WaitUntilDocumentIsReady(this IWebDriver driver, int waitTime)
        {
            IWait<IWebDriver> _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            _wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(waitTime));
            Thread.Sleep(3000);
        }

        public static void HoverTo(this IWebDriver driver, IWebElement element)
        {
            Actions _action = new Actions(driver);
            _action.MoveToElement(element).Perform();
        }

        public static string TableValue(this IWebDriver driver, Table _table, string _columnName)
        {
            ScenarioContext.Current.UpdateFromTable(_table);
            ScenarioContext _context = ScenarioContext.Current;
            string _checkboxValue = _context.Get<string>(_columnName);
            return _checkboxValue;
        }
    }
}
