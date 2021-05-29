using System.Windows.Forms;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace BaseProject.Extensions
{
    public static class WindowManager
    {
        public static void OpenInNewWindow(this IWebDriver driver, IWebElement element, string parentWindow)
        {
            NewWindowAction(driver, element);
            driver.WaitUntilDocumentIsReady(30);
            SwitchNewWindow(driver, parentWindow, element);
            //Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        public static void NewWindowAction(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.KeyDown(OpenQA.Selenium.Keys.Control).Perform();
            element.Click();
            action.KeyUp(OpenQA.Selenium.Keys.Control).Perform();
            //Thread.Sleep(2000);
            //Actions _action = new Actions(driver);
            //_action.MoveToElement(element).ContextClick().Build().Perform();
            //if (TestConfig.Driver == "ie")
            //{
            //    Thread.Sleep(1000);
            //    SendKeys.SendWait("n");
            //}
            //else
            //{
            //    Thread.Sleep(1000);
            //    SendKeys.SendWait("w");
            //}

        }

        public static void CloseCurrentWindow(this IWebDriver driver, string parentWindow)
        {
            //string childHandle = null;
            //while (parentWindow == driver.CurrentWindowHandle.ToString())
            //{
            //    childHandle = driver.WindowHandles.Last().ToString();
            //    driver.SwitchTo().Window(childHandle);
            //    Thread.Sleep(1000);
            //}

            driver.Close();
            ReturnToParentWindow(driver, parentWindow);
        }

        public static void SwitchNewWindow(IWebDriver driver, string ParentHandle, IWebElement element)
        {
            string _childHandle = null;

            _childHandle = GetChildWindow(driver);
            driver.SwitchTo().Window(_childHandle);

            while (driver.CurrentWindowHandle.ToString() == ParentHandle)
            {
                SendKeys.SendWait("%" + "{F4}");
                driver.SwitchTo().Window(ParentHandle);
                NewWindowAction(driver, element);
                Thread.Sleep(2000);
                SwitchNewWindow(driver, ParentHandle, element);
                //Thread.Sleep(1000);
                driver.Manage().Window.Maximize();
                Thread.Sleep(1000);
            }

            _childHandle = GetChildWindow(driver);
            driver.SwitchTo().Window(_childHandle);
        }

        public static void ReturnToParentWindow(IWebDriver driver, string _parentWindow)
        {
            driver.SwitchTo().Window(_parentWindow);
        }

        public static string GetParentWindow(this IWebDriver driver)
        {
            string _parentHandle = null;
            _parentHandle = driver.CurrentWindowHandle.ToString();
            return _parentHandle;
        }

        public static string GetChildWindow(IWebDriver driver)
        {
            string _childHandle = null;
            string parentwindow = null;
            parentwindow = driver.WindowHandles.First().ToString();
            _childHandle = driver.WindowHandles.Last().ToString();
            

            //while (_childHandle == parentwindow)
            //{
                
            //    Thread.Sleep(1000);
            //    _childHandle = driver.WindowHandles.Last().ToString();
            //}

            return _childHandle;
        }

     }
}