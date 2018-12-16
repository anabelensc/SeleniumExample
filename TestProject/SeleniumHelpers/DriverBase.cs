using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;


namespace seleniumtestexample
{
    [TestFixture]
    public class DriverBase : DriverFactory
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;

        private BrowserType _browserType;

        public DriverBase(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [OneTimeSetUp]
        public void OneTimeSetUpTest()
        {
            try
            {

                ExtentManager.Instance = ExtentManager.CreateExtentReportObject();
                _extent = ExtentManager.Instance;

            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [SetUp]
        public void InitializeTest()
        {

            try
            {
                GetDriver(_browserType);
               
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [TearDown]
        public void FinalizeTest()
        {
           
            try
            {
                if (ExtentManager.Instance == null)
                    return;

                var status = TestContext.CurrentContext.Result.Outcome.Status;
                string screenShotPath = null;

                LogStatus logStatus;

                switch (status)
                {
                    case TestStatus.Failed:
                        logStatus = LogStatus.Fail;

                        var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                        var errorMessage = TestContext.CurrentContext.Result.Message;

                        screenShotPath = ReportHelper.Capture(_driver, TestContext.CurrentContext.Test.MethodName);

                        _test.Log(logStatus, "Test ended with " + logStatus + " ---------- " + errorMessage);
                        _test.Log(logStatus, "Snapshot below: " + _test.AddScreenCapture(screenShotPath));

                        break;

                    case TestStatus.Skipped:
                        logStatus = LogStatus.Skip;
                      
                        break;

                    default:
                        logStatus = LogStatus.Pass;
                   
                        _test.Log(logStatus, "Test ended with " + logStatus);

                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                if (_driver != null)
                    _driver.Quit();

                _extent.EndTest(_test);
                _extent.Flush();            
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDownTest()
        {
            if (ExtentManager.Instance == null)
                return;

            try
            {
                if (_driver != null)
                    _driver.Quit();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
