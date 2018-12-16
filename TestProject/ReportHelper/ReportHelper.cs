using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace seleniumtestexample
{
    internal class ExtentManager
    {
        public static ExtentReports Instance;

        private ExtentManager() { }

        /// <summary>
        /// Returns a instance of ExtentReports object
        /// </summary>
        /// <returns></returns>
        public static ExtentReports CreateExtentReportObject()
        {
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            String currentPath = path.Substring(0, path.LastIndexOf("bin"));
            String projectPath = new Uri(currentPath).LocalPath;
            String reportPath = projectPath + "Reports//Reports.html";

            try
            {
                ExtentReports _extent = new ExtentReports(reportPath, true);

                _extent.AddSystemInfo("Enviroment", "QA");
                _extent.LoadConfig(projectPath + "extent-config.xml");

                return _extent;
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
    }
    public static class ReportHelper
    {
        public static String Capture(IWebDriver driver, String screenShotName)
        {
            string localpath = "";
            Screenshot ss = null;

            string path = System.AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();

                localpath = path + "Reports\\" + screenShotName + ".Png";
                ss.SaveAsFile(localpath);

            }
            catch (Exception e)
            {
                throw (e);
            }

            return localpath;
        }
    }
}