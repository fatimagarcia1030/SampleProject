using System;
using TechTalk.SpecFlow;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using BaseProject.PageModels;
using BaseProject.Extensions;

namespace BaseProject.AcceptanceTests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver _driver;
        private Class1 _class1;

        public SpecFlowFeature1Steps(IWebDriver driver
            , Class1 class1)
        {
            _driver = driver;
            _class1 = class1;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _driver.Manage().Window.Maximize();
            _driver.NavigateToHomePage();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
