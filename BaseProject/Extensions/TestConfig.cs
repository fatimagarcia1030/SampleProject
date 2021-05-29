using System;
using System.Configuration;
using System.IO;

namespace BaseProject.Extensions
{
    public class TestConfig
    {
        public static string _homePage;
        public static string _webDriversPath;
        public static string _driver;
        public static string _username;
        public static string _password;


        public static string HomePage
        {
            get
            {
                _homePage = _homePage ?? ConfigurationManager.AppSettings["HomePage"];
                return _homePage;
            }
        }


        public static string Driver
        {
            get
            {
                _driver = _driver ?? GetDriverType();
                return _driver;
            }
        }

        public static string WebDriversPath
        {
            get
            {
                _webDriversPath = _webDriversPath ?? GetWebDriversPath();
                return _webDriversPath;
            }
        }

        private static string GetDriverType()
        {
            string driver = "chrome";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Driver"]))
                driver = ConfigurationManager.AppSettings["Driver"];
            return driver;
        }

        private static string GetWebDriversPath()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WebDriversPath"]))
                return ConfigurationManager.AppSettings["WebDriversPath"];

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.GetFullPath(string.Format("{0}\\..\\..\\..\\WebDrivers", baseDirectory));
        }
    }
}
    