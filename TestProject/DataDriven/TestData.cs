using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumtestexample
{
    public class TestData
    {
        public static IEnumerable ValueOfSearch
        {
            get { return DataDrivenHelper.ReadDataDrivenFile(ProjectBaseConfiguration.DataDrivenFile, "valueofsearch"); }
           
        }
        public static IEnumerable ValueOfSearchWrongRessult
        {
            get { return DataDrivenHelper.ReadDataDrivenFile(ProjectBaseConfiguration.DataDrivenFile, "valueofsearchwrongressult"); }
        }
    }
}

