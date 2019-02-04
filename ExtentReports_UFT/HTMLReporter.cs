using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace UFT_Extent_Reports
{
    public class HTMLReporter
    {
        public ExtentReports extent;
        public ExtentHtmlReporter extentHtmlReporter;
        public ExtentTest extentTest;
        String FilePath = "";

        public ExtentReports GetExtentObject()
        {
            return extent;
        }

        public ExtentHtmlReporter GetHTMLReporterObject()
        {
            return extentHtmlReporter;
        }

        public Boolean ChangeToDarkTheme()
        {
            extentHtmlReporter.Config.Theme = Theme.Dark;
            return true;
        }

        public Boolean ChangeToStandardTheme()
        {
            extentHtmlReporter.Config.Theme = Theme.Standard;
            return true;
        }

        public Boolean InitializeReport(string reportPath)
        {
            try
            {
                extent = new ExtentReports();
                extentHtmlReporter = new ExtentHtmlReporter(reportPath);
                extent.AttachReporter(extentHtmlReporter);
                FilePath = reportPath;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n' + ex.StackTrace + '\n' + ex.Source + '\n' + ex.InnerException);
                return false;
            }
        }

        public Boolean CreateTest(String testName, String Description = null)
        {
            try
            {
                extentTest = extent.CreateTest(testName, Description);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + '\n' + ex.StackTrace.ToString());
                return false;
            }

        }

        public Boolean AddPassLog(String Message, String ScreenshotPath = "", String ScreenShotTitle = "")
        {
            if (ScreenshotPath == "")
                extentTest.Pass(Message);
            else
                extentTest.Pass(Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath, ScreenShotTitle).Build());

            return true;
        }

        public Boolean AddFailLog(String Message, String ScreenshotPath = "", String ScreenShotTitle = "")
        {
            if (ScreenshotPath == "")
                extentTest.Fail(Message);
            else
                extentTest.Fail(Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath, ScreenShotTitle).Build());

            return true;
        }

        public Boolean SetTimeLine(Boolean EnableTimeLine = true)
        {
            extentHtmlReporter.Config.EnableTimeline = EnableTimeLine;
            
            return true;
        }

        public Boolean AddDeviceToTest(String DeviceName)
        {
            extentTest.AssignDevice(DeviceName);
            return true;
        }

        public Boolean AddInfoLog(String Message, String ScreenshotPath = "", String ScreenShotTitle = "")
        {
            if (ScreenshotPath == "")
                extentTest.Info(Message);
            else
                extentTest.Info(Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath, ScreenShotTitle).Build());

            return true;
        }

        public Boolean AddErrorLog(String Message, String ScreenshotPath = "", String ScreenShotTitle = "")
        {
            if (ScreenshotPath == "")
                extentTest.Error(Message);
            else
                extentTest.Error(Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath, ScreenShotTitle).Build());

            return true;
        }

        public Boolean AddFatalLog(String Message, String ScreenshotPath = "", String ScreenShotTitle = "")
        {
            if (ScreenshotPath == "")
                extentTest.Fatal(Message);
            else
                extentTest.Fatal(Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotPath, ScreenShotTitle).Build());

            return true;
        }

        public Boolean AssignCategoryToTest(String categoryName)
        {
            extentTest.AssignCategory(categoryName);
            return true;
        }

        public Boolean AssignAuthorToTest(String authorName)
        {
            extentTest.AssignAuthor(authorName);
            return true;
        }

        public Boolean AddDocumentTitle(String title)
        {
            extentHtmlReporter.Config.DocumentTitle = title;
            return true;
        }

        public Boolean AddReportName(String title)
        {
            extentHtmlReporter.Config.ReportName = title;
            return true;
        }

        public Boolean GenerateReport()
        {
            extent.Flush();
            return true;
        }

        public Boolean AddSystemInfo(String Name, String Value)
        {
            extent.AddSystemInfo(Name, Value);
            return true;
        }

        public Boolean LoadConfig(String FilePath)
        {
            extentHtmlReporter.LoadConfig(FilePath);
            return true;
        }
    }
}
