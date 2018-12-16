using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using NUnit.Framework;

namespace seleniumtestexample
{
    public static class DataDrivenHelper
    {
        public static IEnumerable<TestCaseData> ReadDataDrivenFile(string folder, string testData)
        {
            var doc = XDocument.Load(folder);
            if (!doc.Descendants(testData).Any())
            {
                throw new ArgumentNullException();
            }

            return doc.Descendants(testData).Select(element => element.Attributes().ToDictionary(k => k.Name.ToString(), v => v.Value)).Select(testParams => new TestCaseData(testParams));

        }
    }
}