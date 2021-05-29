using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;


namespace BaseProject.Extensions
{
    [Binding]
    public class TestManager
    {
        private readonly IObjectContainer _container;
        private static IWebDriver _driver;


        public TestManager(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            
        }

        [AfterFeature]
        public static void AfterFeature()
        {

        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = WebDriverManager.Current.GetDefaultWebDriver();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }


        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
