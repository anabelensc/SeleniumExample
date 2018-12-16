using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;

namespace seleniumtestexample
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement txtSearchField => _driver.FindElement(By.Name("q"));
        IWebElement btnSearch => _driver.FindElement(By.Name("btnK"));

        public void SearchTheWord(IDictionary<string, string> parameters)
        {
            _driver.Navigate().GoToUrl(parameters["page"]);

            txtSearchField.Clear();
            txtSearchField.SendKeys(parameters["word"]);

            System.Threading.Thread.Sleep(5000);

            btnSearch.Click();
        }
    }
}
