using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace seleniumtestexample
{
    public class DriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public IWebDriver _driver { get; set; }

        public void GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    _driver = new FirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
