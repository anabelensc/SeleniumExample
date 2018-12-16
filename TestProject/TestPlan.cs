using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace seleniumtestexample
{

    [TestFixture]
    public class ChromeTesting : DriverBase
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {

        }

        [Test]
        [TestCaseSource(typeof(TestData), "ValueOfSearchWrongRessult")]
        public void GoogleSearchWrongTest(IDictionary<string, string> parameters)
        {
            // Arrange
            var searchPage = new SearchPage(_driver);
            _test = _extent.StartTest("Wrong Google search google test start ");
            _test.Log(LogStatus.Info, "Wrong Google search google test");

            // Act
            _test.Log(LogStatus.Info, "Search the word: " + parameters["word"]);
            searchPage.SearchTheWord(parameters);

            // Assert
           
            Action resultTest = () =>
            {
                var displayed = _driver.PageSource.Contains(parameters["wordresult"]).Should().BeTrue(); // throws exception if not found

            };
            resultTest.Should().Throw<Exception>();
            _test.Log(LogStatus.Info, "Check the search word: " + parameters["wordresult"]);
            _test.Log(LogStatus.Info, "Throw an exception the test ");
        }

        [Test]
        [TestCaseSource(typeof(TestData), "ValueOfSearch")]
        public void GoogleSearchRightTest(IDictionary<string, string> parameters)
        {
            // Arrange
            var searchPage = new SearchPage(_driver);

            _test = _extent.StartTest("Right Google search google test start");
            _test.Log(LogStatus.Info, "Right Google search google test");

            // Act
            _test.Log(LogStatus.Info, "Search the word: "+ parameters["word"]);
            searchPage.SearchTheWord(parameters);

            // Assert
            _test.Log(LogStatus.Info, "Check the search word: " + parameters["word"]);
            Assert.That(_driver.PageSource.Contains(parameters["word"]), Is.EqualTo(true), "Fail doest not exist");
           
        }
    }
}
