using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BaseProject.Extensions;

namespace BaseProject.PageModels
{
    public class Class1
    {
        private IWebDriver Driver;

        private IWebElement _elementName;
        public Class1(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement ElementName
        {
            get
            {
                _elementName = Driver.FindElement(20, By.XPath("xpathvalue"));
                return _elementName;
            }
        }
    }
}
